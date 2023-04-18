using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PickUpItem : MonoBehaviour
{
    [SerializeField] private float _magnetRadius = 3f;
    [SerializeField] private float _magnetForce = 10f;
    [SerializeField] private Player _player;
    
    private AudioSource _sound;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Attract();
    }

    private void Attract()
    {
        Collider2D[] drops = Physics2D.OverlapCircleAll(transform.position, _magnetRadius);

        foreach (Collider2D drop in drops)
        {
            if (drop.gameObject.TryGetComponent(out Drop item))
            {
                Rigidbody2D rb = drop.gameObject.GetComponent<Rigidbody2D>();
                Vector2 direction = transform.position - drop.gameObject.transform.position;
                rb.AddForce(direction.normalized * _magnetForce);
            }       
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Drop drop))
        {
            Destroy(collision.gameObject);
            _player.IncreaseDrops();
            _sound.PlayOneShot(_sound.clip);
        }
    }
}

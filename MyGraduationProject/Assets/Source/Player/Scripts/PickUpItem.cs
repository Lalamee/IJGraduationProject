 using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PickUpItem : MonoBehaviour
{
    [SerializeField] private float _magnetRadius = 3f;
    [SerializeField] private float _magnetForce = 10f;
    [SerializeField] private Player _player;

    private bool _isReadyForAttract = true;
    private float _attractInterval = 0.005f;
    private AudioSource _sound;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        StartCoroutine(AttractCoroutine());
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Drop drop))
        {
            Destroy(drop.gameObject);
            _player.IncreaseDrops();
            _sound.PlayOneShot(_sound.clip);
        }
    }

    private IEnumerator AttractCoroutine()
    {
        var waitForDelay = new WaitForSeconds(_attractInterval);
        
        while (_isReadyForAttract) 
        {
            Collider2D[] drops = Physics2D.OverlapCircleAll(transform.position, _magnetRadius);
            
            foreach (Collider2D drop in drops) 
            {
                if (drop.gameObject.TryGetComponent(out Drop item)) 
                {
                    Vector2 direction = transform.position - drop.gameObject.transform.position;
                    item.Rigidbody.AddForce(direction.normalized * _magnetForce);
                }
            }
            
            yield return waitForDelay;
        }
    }
}

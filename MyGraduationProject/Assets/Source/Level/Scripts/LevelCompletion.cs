using UnityEngine;
using UnityEngine.Events;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] private UnityEvent _finish;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            PlayerPrefs.SetInt("Coble", player.GetCountCoble());
            PlayerPrefs.Save();
            _finish?.Invoke();
        }
    }
}

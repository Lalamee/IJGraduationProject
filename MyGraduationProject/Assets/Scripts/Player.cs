using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _checkRay;

    public event UnityAction<int> CountDropsChanged;

    private const string Run = "Run";
    private const string Idle = "Idle";
    private bool _inMove;
    private int _countDrops;
    private float _range = 0.02f;
    private string _currentAnimation;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentAnimation = Run;
    }

    private void Update()
    {
        _inMove = CheckDistance(_range, _checkRay);
        
        Move(_inMove);
    }

    private void ChangeAnimation(string animation)
    {
        if (_currentAnimation == animation) 
            return;

        _animator.SetBool(_currentAnimation,false);
        _animator.SetBool(animation, true);
        _currentAnimation = animation;
    }
    
    private bool CheckDistance(float range, GameObject ray)
    {
        RaycastHit2D hit = Physics2D.Raycast(ray.transform.position, transform.right, range );

        if (hit)
            return false;
        
        return true;
    }

    private void Move(bool inMove)
    {
        if (inMove)
        {
            transform.Translate(_speed * Time.deltaTime,0,0 );
            ChangeAnimation(Run);
        }
        else
        {
            transform.Translate(0,0,0 );
            ChangeAnimation(Idle);
        }
    }

    public void IncreaseDrops()
    {
        _countDrops++;
        CountDropsChanged?.Invoke(_countDrops);
    }
}

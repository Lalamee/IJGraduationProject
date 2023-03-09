using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    [SerializeField] private GameObject _ray;

    private bool _inMove;

    private void Update()
    {
        _inMove = CheckDistance(_range, _ray);
        
        Move(_inMove);
    }

    private bool CheckDistance(float range, GameObject Ray)
    {
        RaycastHit2D hit = Physics2D.Raycast(_ray.transform.position, transform.right, range);
        Debug.DrawRay(_ray.transform.position, transform.right, Color.blue, range);

        if (hit)
            return false;
        else
            return true;
    }

    private void Move(bool inMove)
    {
        if(inMove)
            transform.Translate(_speed * Time.deltaTime,0,0 );
        else
            transform.Translate(0,0,0 );
    }
}

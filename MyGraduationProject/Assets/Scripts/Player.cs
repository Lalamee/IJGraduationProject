using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _checkRay;
    
    private bool _inMove;
    private float _range = 0.5f;

    private void Update()
    {
        _inMove = CheckDistance(_range, _checkRay);
        
        Move(_inMove);
    }

    private bool CheckDistance(float range, GameObject ray)
    {
        RaycastHit2D hit = Physics2D.Raycast(ray.transform.position, transform.right, range);

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

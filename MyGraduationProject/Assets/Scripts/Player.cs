using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _upRay;
    [SerializeField] private GameObject _downRay;
    
    private bool _inMove;
    private float _range = 0.5f;

    private void Update()
    {
        _inMove = CheckDistance(_range, _upRay, _downRay);
        
        Move(_inMove);
    }

    public bool CheckDistance(float range, GameObject upRay, GameObject downRay)
    {
        RaycastHit2D upHit = Physics2D.Raycast(upRay.transform.position, transform.right, range);
        RaycastHit2D downHit = Physics2D.Raycast(downRay.transform.position, transform.right, range);

        if (upHit || downHit)
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

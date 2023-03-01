using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    [SerializeField] private GameObject _blocks;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime,0,0 );

        CheckDistance(_range, _blocks);
    }

    private void CheckDistance(float range, GameObject block)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range);

        if (hit.collider == block)
            transform.Translate(_speed * Time.deltaTime,0,0 );
    }
}

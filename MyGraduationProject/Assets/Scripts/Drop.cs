using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Drop : MonoBehaviour
{
    public Rigidbody2D Rigidbody { get; private set; }

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }
}

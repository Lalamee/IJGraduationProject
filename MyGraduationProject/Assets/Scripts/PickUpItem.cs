using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PickUpItem : MonoBehaviour
{
    [SerializeField] private float _magnetRadius = 3f;
    [SerializeField] private float _magnetForce = 10f;
    
    private AudioSource _sound;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Attraction();
    }

    private void Attraction()
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
            _sound.PlayOneShot(_sound.clip);
            Destroy(collision.gameObject);
        }
    }
}

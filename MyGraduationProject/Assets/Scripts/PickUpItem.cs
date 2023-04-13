using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PickUpItem : MonoBehaviour
{
    [SerializeField] private float _magnetRadius = 3f;
    [SerializeField] private float _magnetForce = 10f;
    [SerializeField] private AudioClip _pickUpSound;
    
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
                   
        }
    }
}

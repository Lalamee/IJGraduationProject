using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

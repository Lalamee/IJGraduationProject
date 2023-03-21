using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _upRay;
    [SerializeField] private GameObject _downRay;
    
    private float _range = 0.5f;
    private Tilemap _cave;
    private GridLayout _grid;
    private Vector2 _mousePosition; 
    private Vector3Int _blockPosition;

    private void Start()
    {
        _cave = GetComponent<Tilemap>();
        _grid = GetComponent<GridLayout>();
    }

    private void Update()
    {
        Destroy();
    }
    
    private void Destroy()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _blockPosition = _grid.WorldToCell(_mousePosition);
        
        if (Input.GetMouseButton(0))
                _cave.SetTile(_blockPosition, null);
    }
}

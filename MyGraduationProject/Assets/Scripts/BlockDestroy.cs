using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockDestroy : MonoBehaviour
{   
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
        Vector3Int blockPosition = FindBlockPosition();
        Destroy(blockPosition);
    }

    private Vector3Int FindBlockPosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _blockPosition = _grid.WorldToCell(_mousePosition);

        return _blockPosition;
    }

    private void Destroy(Vector3Int blockPosition)
    {
        if (Input.GetMouseButton(0))
            _cave.SetTile(blockPosition, null);
    }
}

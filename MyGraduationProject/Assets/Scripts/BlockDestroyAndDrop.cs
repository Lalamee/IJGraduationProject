using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockDestroyAndDrop : MonoBehaviour
{
    [SerializeField] private GameObject _drop;
    
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
        bool isDestroy = IsDestroy(blockPosition);
        CreateDrop(isDestroy);
    }

    private Vector3Int FindBlockPosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _blockPosition = _grid.WorldToCell(_mousePosition);

        return _blockPosition;
    }

    private bool IsDestroy(Vector3Int blockPosition)
    {
        if (Input.GetMouseButton(0))
        {
            _cave.SetTile(blockPosition, null);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CreateDrop(bool isDestoy)
    {
        if (isDestoy)
        {
            Instantiate(_drop, _mousePosition, quaternion.identity);
            isDestoy = false;
        }
    }
}

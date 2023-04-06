using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockDestroyAndCreateDrop : MonoBehaviour
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
        CreateDrop(IsDestroy());
    }
    
    private bool IsDestroy()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _blockPosition = _grid.WorldToCell(_mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (_cave.GetTile(_blockPosition) != null)
            {
                _cave.SetTile(_blockPosition, null);

                return true;
            }
        }

        return false;
    }

    private void CreateDrop(bool isDestroy)
    {
        if(isDestroy)
            Instantiate(_drop, _blockPosition, Quaternion.identity);
    }
}

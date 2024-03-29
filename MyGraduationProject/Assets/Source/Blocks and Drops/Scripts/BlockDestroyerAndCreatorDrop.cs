using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Tilemap))]
[RequireComponent(typeof(GridLayout))]
public class BlockDestroyerAndCreatorDrop : MonoBehaviour
{
    [SerializeField] private GameObject _drop;
    
    private Tilemap _cave;
    private GridLayout _grid;
    private AudioSource _sound;
    private Vector2 _mousePosition; 
    private Vector3Int _blockPosition;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _cave = GetComponent<Tilemap>();
        _grid = GetComponent<GridLayout>();
    }

    private void Update()
    {
        if(IsDestroyBlock())
            CreateDrop();
    }
    
    private bool IsDestroyBlock()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _blockPosition = _grid.WorldToCell(_mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (_cave.GetTile(_blockPosition) != null)
            {
                _cave.SetTile(_blockPosition, null);
                _sound.PlayOneShot(_sound.clip);
                
                return true;
            }
        }

        return false;
    }

    private void CreateDrop()
    {
        Instantiate(_drop, _mousePosition, Quaternion.identity);
    }
}

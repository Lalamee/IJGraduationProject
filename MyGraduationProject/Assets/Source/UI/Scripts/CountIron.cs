using TMPro;
using UnityEngine;

public class CountIron : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _count;
    
    private void OnEnable()
    {
        _player.CountIronChanged += OnCountScoreChange;
    }

    private void OnDisable()
    {
        _player.CountIronChanged -= OnCountScoreChange;
    }

    private void OnCountScoreChange(int count)
    {
        _count.text = count.ToString();
    }
}

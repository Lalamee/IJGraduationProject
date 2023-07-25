using TMPro;
using UnityEngine;

public class CountGold : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _count;
    
    private void OnEnable()
    {
        _player.CountGoldChanged += OnCountScoreChange;
    }

    private void OnDisable()
    {
        _player.CountGoldChanged -= OnCountScoreChange;
    }

    private void OnCountScoreChange(int count)
    {
        _count.text = count.ToString();
    }
}

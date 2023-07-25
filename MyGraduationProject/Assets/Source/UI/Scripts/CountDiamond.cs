using TMPro;
using UnityEngine;

public class CountDiamond : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _count;
    
    private void OnEnable()
    {
        _player.CountDiamondChanged += OnCountScoreChange;
    }

    private void OnDisable()
    {
        _player.CountDiamondChanged -= OnCountScoreChange;
    }

    private void OnCountScoreChange(int count)
    {
        _count.text = count.ToString();
    }
}

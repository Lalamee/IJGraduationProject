using UnityEngine;
using TMPro;

public class CountDrop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _count;

    private void OnEnable()
    {
        _player.CountDropsChanged += OnCountScoreChange;
    }

    private void OnDisable()
    {
        _player.CountDropsChanged -= OnCountScoreChange;
    }

    private void OnCountScoreChange(int count)
    {
        _count.text = count.ToString();
    }
}

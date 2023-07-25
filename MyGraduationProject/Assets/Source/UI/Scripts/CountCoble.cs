using UnityEngine;
using TMPro;

public class CountCoble : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _count;
    
    private void OnEnable()
    {
        _player.CountCobleChanged += OnCountScoreChange;
    }

    private void OnDisable()
    {
        _player.CountCobleChanged -= OnCountScoreChange;
    }

    private void OnCountScoreChange(int count)
    {
        _count.text = count.ToString();
    }
}

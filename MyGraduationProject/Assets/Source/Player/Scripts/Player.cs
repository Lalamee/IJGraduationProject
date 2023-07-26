using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private const string Run = "Run";
    private const string Idle = "Idle";
    private const string Coble = "Coble";
    private const string Iron = "Iron";
    private const string Diamond = "Diamond";
    private const string Oil = "Oil";
    private const string Gold = "Gold";
    
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _checkRay;
    
    private bool _inMove;
    private int _countDrops;
    private int _countOil;
    private int _countDiamond;
    private int _countCoble;
    private int _countGold;
    private int _countIron;

    private float _range = 0.02f;
    private string _currentAnimation;
    private Animator _animator;
    
    public event UnityAction<int> CountOilChanged;
    public event UnityAction<int> CountDiamondChanged;
    public event UnityAction<int> CountCobleChanged;
    public event UnityAction<int> CountGoldChanged;
    public event UnityAction<int> CountIronChanged;

    private void Awake()
    {
        _countCoble = PlayerPrefs.GetInt(Coble);
        CountCobleChanged?.Invoke(_countCoble);
        
        _countOil = PlayerPrefs.GetInt(Oil);
        CountOilChanged?.Invoke(_countOil);
        
        _countIron = PlayerPrefs.GetInt(Iron);
        CountIronChanged?.Invoke(_countIron);
        
        _countGold = PlayerPrefs.GetInt(Gold);
        CountGoldChanged?.Invoke(_countGold);
        
        _countDiamond = PlayerPrefs.GetInt(Diamond);
        CountDiamondChanged?.Invoke(_countDiamond);
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentAnimation = Run;
    }
    
    private void Update()
    {
        _inMove = CheckDistance(_range, _checkRay);
        Move(_inMove);
    }
    
    public void IncreaseCoble()
    {
        _countCoble++;
        CountCobleChanged?.Invoke(_countCoble);
    }
    
    public void IncreaseDiamond()
    {
        _countDiamond++;
        CountDiamondChanged?.Invoke(_countDiamond);
    }
    
    public void IncreaseGold()
    {
        _countGold++;
        CountGoldChanged?.Invoke(_countGold);
    }
    
    public void IncreaseIron()
    {
        _countIron++;
        CountIronChanged?.Invoke(_countIron);
    }
    
    public void IncreaseOil()
    {
        _countOil++;
        CountOilChanged?.Invoke(_countOil);
    }
    
    public void SaveDrpos()
    {
        PlayerPrefs.SetInt(Coble, _countCoble);
        PlayerPrefs.SetInt(Oil, _countOil);
        PlayerPrefs.SetInt(Iron, _countIron);
        PlayerPrefs.SetInt(Gold, _countGold);
        PlayerPrefs.SetInt(Diamond, _countDiamond);
        PlayerPrefs.Save();
    }
    
    private void ChangeAnimation(string animation)
    {
        if (_currentAnimation == animation) 
            return;

        _animator.SetBool(_currentAnimation,false);
        _animator.SetBool(animation, true);
        _currentAnimation = animation;
    }
    
    private bool CheckDistance(float range, GameObject ray)
    {
        int layerMask = LayerMask.GetMask("Cave");
        
        RaycastHit2D hit = Physics2D.Raycast(ray.transform.position, transform.right, range, layerMask);

        if (hit)
            return false;
        
        return true;
    }
    
    private void Move(bool inMove)
    {
        if (inMove)
        {
            transform.Translate(_speed * Time.deltaTime,0,0 );
            ChangeAnimation(Run);
        }
        else
        {
            transform.Translate(0,0,0 );
            ChangeAnimation(Idle);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Action<int> OnLifesChanged;
    public static Action<PlayerMotor> OnDeath;
    public static Action<PlayerMotor> OnRevive;
    
    [Header("Settings")] 
    [SerializeField] private int lifes = 3;

    /// <summary>
    /// 
    /// </summary>
    public int MaxLifes => _maxLifes;
    
    /// <summary>
    /// 
    /// </summary>
    public int CurrentLifes => _currentLifes;
    
    private int _maxLifes;
    private int _currentLifes;

    private void Awake()
    {
        _maxLifes = lifes;
    }

    private void Start()
    {
        ResetLife();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            LoseLife();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void AddLife()
    {
        _currentLifes += 1;
        if (_currentLifes > _maxLifes)
        {
            _currentLifes = _maxLifes;
        }
        
        UpdateLifesUI();
    }

    /// <summary>
    /// 
    /// </summary>
    public void LoseLife()
    {
        _currentLifes -= 1;
        if (_currentLifes <= 0)
        {
            _currentLifes = 0;
            OnDeath?.Invoke(gameObject.GetComponent<PlayerMotor>());
        }
        UpdateLifesUI();
    }

    /// <summary>
    /// 
    /// </summary>
    public void KillPlayer()
    {
        _currentLifes = 0;
        UpdateLifesUI();
        OnDeath?.Invoke(gameObject.GetComponent<PlayerMotor>());
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void ResetLife()
    {
        _currentLifes = lifes;
        UpdateLifesUI();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Revive()
    {
        OnRevive?.Invoke(gameObject.GetComponent<PlayerMotor>());
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void UpdateLifesUI()
    {
        OnLifesChanged?.Invoke(_currentLifes);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().Damage(gameObject.GetComponent<PlayerMotor>());
        }
    }
}

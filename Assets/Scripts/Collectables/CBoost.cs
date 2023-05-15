using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBoost : Collectable
{
    [Header("Settings")]
    [SerializeField] private float boostSpeed = 15f;
    [SerializeField] private float boostTime = 3f;
    
    private PlayerMovement _playerMovement;
    
    protected override void Collect()
    {
        ApplyMovement();
    }

    /// <summary>
    /// Apply that movement bonus
    /// </summary>
    private void ApplyMovement()
    {
        _playerMovement = _playerMotor.GetComponent<PlayerMovement>();
        if (_playerMovement != null)
        {
            StartCoroutine(IEBoost());
        }
    }

    /// <summary>
    /// Add boost to our player movement
    /// </summary>
    /// <returns></returns>
    private IEnumerator IEBoost()
    {
        _playerMovement.Speed = boostSpeed;
        yield return new WaitForSeconds(boostTime);
        _playerMovement.Speed = _playerMovement.InitialSpeed;
    }
}

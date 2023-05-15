using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    protected PlayerMotor _playerMotor;
    protected SpriteRenderer _spriteRenderer;
    protected Collider2D _collider2D;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
    }

    /// <summary>
    /// Contains the logic of the colletable 
    /// </summary>
    private void CollectLogic()
    {
        if (!CanBePicked())
        {
            return;
        }
        
        Collect();
        DisableCollectable();
    }

    /// <summary>
    /// Override to add custom colletable behaviour
    /// </summary>
    protected virtual void Collect()
    {
        
    }

    /// <summary>
    /// Disable the spriteRenderer and collider of the Collectable
    /// </summary>
    private void DisableCollectable()
    {
        _collider2D.enabled = false;
        _spriteRenderer.enabled = false;
    }
    
    /// <summary>
    /// Returns if this colletable can pe picked, True if it is colliding with the player
    /// </summary>
    /// <returns></returns>
    private bool CanBePicked()
    {
        return _playerMotor != null;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMotor>() != null)
        {
            _playerMotor = other.GetComponent<PlayerMotor>();
            CollectLogic();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _playerMotor = null;
    }
}

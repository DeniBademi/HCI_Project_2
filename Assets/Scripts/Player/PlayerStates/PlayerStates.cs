using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    protected PlayerController _playerController;
    protected Animator _animator;
    protected float _horizontalInput;
    protected float _verticalInput;

    protected virtual void Start()
    {
        InitState();
    }

    /// <summary>
    /// Here we call some logic we need in start
    /// </summary>
    protected virtual void InitState()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }
    
    /// <summary>
    /// Override in order to create the state logic
    /// </summary>
    public virtual void ExecuteState()
    {
        if (GameManager.Instance.GameState == GameManager.GameStates.LevelCompleted)
        {
            return;
        }
    }

    /// <summary>
    /// Gets the normal Input
    /// </summary>
    public virtual void LocalInput()
    { 
        if (GameManager.Instance.GameState == GameManager.GameStates.LevelCompleted)
        {
            return;
        }
        
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        
        GetInput();
    }

    /// <summary>
    /// Override to support other Inputs
    /// </summary>
    protected virtual void GetInput()
    {
        
    }

    public virtual void SetAnimation()
    {
         
    }
}

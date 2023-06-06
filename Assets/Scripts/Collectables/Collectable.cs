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
    /// Contains the logic of the collectable 
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
    /// Override to add custom collectable behavior
    /// </summary>
    protected virtual void Collect()
    {

    }

    /// <summary>
    /// Disable the spriteRenderer and collider of the collectable
    /// </summary>
    private void DisableCollectable()
    {
        _collider2D.enabled = false;
        _spriteRenderer.enabled = false;
    }

    /// <summary>
    /// Resets the collectable by enabling its collider and sprite renderer
    /// </summary>
    public void ResetCollectable()
    {
        _collider2D.enabled = true;
        _spriteRenderer.enabled = true;
    }

    /// <summary>
    /// Returns if this collectable can be picked, True if it is colliding with the player
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

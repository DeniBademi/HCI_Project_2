using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private float gravity = -20f;

    private BoxCollider2D _boxCollider2D;
    private Vector2 _boundsTopLeft;
    private Vector2 _boundsTopRight;
    private Vector2 _boundsBottomLeft;
    private Vector2 _boundsBottomRight;

    private float _boundsWidth;
    private float _boundsHeight;

    private float _currentGravity;
    private Vector2 _force;
    private Vector2 _movePosition;

    // Start is called before the first frame update
    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        ApplyGravity();
        StartMovement();
        
        SetRayOrigins();

        transform.Translate(_movePosition, Space.Self);

        // Debug.DrawRay(_boundsBottomLeft, Vector2.left, Color.red);
        // Debug.DrawRay(_boundsBottomRight, Vector2.right, Color.red);
        // Debug.DrawRay(_boundsTopLeft, Vector2.left, Color.red);
        // Debug.DrawRay(_boundsTopRight, Vector2.right, Color.red);
    }

    private void StartMovement() 
    {
        _movePosition = _force * Time.deltaTime;
    }
    
    private void ApplyGravity() {
        _currentGravity = gravity;
        _force.y += _currentGravity * Time.deltaTime;
    }

    private void SetRayOrigins() {
        Bounds playerBounds = _boxCollider2D.bounds;

        _boundsBottomLeft = new Vector2(playerBounds.min.x, playerBounds.min.y);
        _boundsBottomRight = new Vector2(playerBounds.max.x, playerBounds.min.y);
        _boundsTopLeft = new Vector2(playerBounds.min.x, playerBounds.max.y);
        _boundsTopRight = new Vector2(playerBounds.max.x, playerBounds.max.y);

        _boundsHeight = Vector2.Distance(_boundsBottomLeft, _boundsTopLeft);
        _boundsWidth = Vector2.Distance(_boundsBottomLeft, _boundsBottomRight);
    }
}

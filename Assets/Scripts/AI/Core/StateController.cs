using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("State")] 
    [SerializeField] private AIState currentState;
    [SerializeField] private AIState remainState;

    [Header("Shooting")] 
    [SerializeField] private Transform firePoint;
    
    /// <summary>
    /// Reference of the Path Follow
    /// </summary>
    public PathFollow Path { get; set; }
    
    /// <summary>
    /// Player Reference
    /// </summary>
    public PlayerMotor Target { get; set; }

    public ObjectPooler Pooler { get; set; }

    public Transform FirePoint => firePoint;
    
    private Vector3 _radiusStartPosition;
    private float _detectionRadius;
    private bool _playerDetected;
    
    private void Start()
    {
        Path = GetComponent<PathFollow>();
        Pooler = GetComponent<ObjectPooler>();
    }

    private void Update()
    {
        currentState.RunState(this);
    }

    /// <summary>
    /// Update our State to a new one
    /// </summary>
    /// <param name="newState">The new state</param>
    public void TransitionToState(AIState newState)
    {
        if (newState != remainState)
        {
            currentState = newState;
        }
    }

    /// <summary>
    /// Create a test line to visualize the ray that we are casting
    /// </summary>
    /// <param name="rayLenght">Lenght of the ray</param>
    /// <param name="startPosition">Cast start position</param>
    /// <param name="direction">Cast Direction</param>
    /// <param name="playerDetected">Returns if we detected our player</param>
    public void DebugRay(float rayLenght, Vector3 startPosition, Vector3 direction, bool playerDetected)
    {
        Debug.DrawLine(startPosition, startPosition + direction * rayLenght, playerDetected ? Color.green : Color.red);
    }

    /// <summary>
    /// Get the detection circle data we want to create
    /// </summary>
    /// <param name="radius">Radius of the circle</param>
    /// <param name="startPosition">Cast start Position</param>
    /// <param name="playerDetection">Returns if we detected our player</param>
    public void SetRediusDetectionValues(float radius, Vector3 startPosition, bool playerDetection)
    {
        _detectionRadius = radius;
        _radiusStartPosition = startPosition;
        _playerDetected = playerDetection;
    }

    private void OnDrawGizmos()
    {
        if (_detectionRadius > 0)
        {
            Gizmos.color = _playerDetected ? Color.green : Color.red;
            Gizmos.DrawWireSphere(_radiusStartPosition, _detectionRadius);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private Vector3 rotateAxis;
    [SerializeField] private float speed = 4f;
    
    private void Update()
    {
        Rotate();
    }

    /// <summary>
    /// 
    /// </summary>
    private void Rotate()
    {
        transform.Rotate(rotateAxis * speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// Destroy this enemy if it is colliding with the player's projectile
    /// </summary>
    /// <param name="objectCollided"></param>
    private void Collision(Collider2D objectCollided)
    {
        if (objectCollided.GetComponent<StateController>() != null)
        {
            Destroy(objectCollided.gameObject);
        }
    }
    
    private void OnEnable()
    {
        ProjectilePooler.OnProjectileCollision += Collision;
    }

    private void OnDisable()
    {
        ProjectilePooler.OnProjectileCollision -= Collision;
    }
}

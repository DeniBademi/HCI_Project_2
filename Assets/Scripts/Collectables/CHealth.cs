using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHealth : Collectable
{
    protected override void Collect()
    {
        AddLife();
    }

    /// <summary>
    /// Adds life
    /// </summary>
    private void AddLife()
    {
        if (_playerMotor.GetComponent<Health>() == null)
        {
            return;
        }

        Health playerHealth = _playerMotor.GetComponent<Health>();
        if (playerHealth.CurrentLifes < playerHealth.MaxLifes)
        {
            playerHealth.AddLife();
        }
    }
}

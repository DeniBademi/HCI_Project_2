using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGun : Collectable
{
    [Header("Settings")] 
    [SerializeField] private Gun gunPrefab;
    
    protected override void Collect()
    {
        EquippGun();
    }

    /// <summary>
    /// Equipp the gun prefab
    /// </summary>
    private void EquippGun()
    {
        if (_playerMotor.GetComponent<GunController>() != null)
        {
            _playerMotor.GetComponent<GunController>().EquippGun(gunPrefab);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private Gun gun;
    [SerializeField] private Transform holder;

    /// <summary>
    /// Reference of the Player owner of the Gun
    /// </summary>
    public PlayerController PlayerController { get; set; }
    
    private Gun _gunEquipped;

    private void Start()
    {
        PlayerController = GetComponent<PlayerController>();
        // EquippGun(gun);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Reload();
        }
    }

    /// <summary>
    /// Shoots Projectiles
    /// </summary>
    private void Shoot()
    {
        if (_gunEquipped != null)
        {
            _gunEquipped.Shoot();
        }
    }

    /// <summary>
    /// Reloads this Gun
    /// </summary>
    private void Reload()
    {
        if (_gunEquipped != null)
        {
            _gunEquipped.Reload(false);
        }
    }
    
    /// <summary>
    /// Equipp a Gun
    /// </summary>
    /// <param name="newGun"></param>
    public void EquippGun(Gun newGun)
    {
        if (_gunEquipped == null)
        {
            _gunEquipped = Instantiate(newGun, holder.position, Quaternion.identity);
            _gunEquipped.GunController = this;
            _gunEquipped.transform.SetParent(holder);
        }
    }
}

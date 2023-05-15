using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    void Damage(PlayerMotor player);
}

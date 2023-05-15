using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : LevelComponent
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    public override void Damage(PlayerMotor player)
    {
        base.Damage(player);
        Debug.Log("SpikeBall");
    }
}

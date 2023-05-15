using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : LevelComponent
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    public override void Damage(PlayerMotor player)
    {
        base.Damage(player);
        Debug.Log("Rock");
    }
}

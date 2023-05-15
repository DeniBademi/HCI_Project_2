using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : ScriptableObject
{
    /// <summary>
    /// Override to add curstom behaviour
    /// </summary>
    /// <param name="controller"></param>
    public abstract void Act(StateController controller);
}

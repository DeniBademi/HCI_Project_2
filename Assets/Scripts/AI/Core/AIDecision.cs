using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : ScriptableObject
{
    /// <summary>
    /// Override to add curstom behaviour
    /// </summary>
    /// <param name="controller"></param>
    /// <returns>True if the condition is correct</returns>
    public abstract bool Decide(StateController controller);
}

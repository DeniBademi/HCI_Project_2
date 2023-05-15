using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public class AIState : ScriptableObject
{
    public AIAction[] Actions;
    public AITransition[] Transitions;

    /// <summary>
    /// Runs this state
    /// </summary>
    /// <param name="controller"></param>
    public void RunState(StateController controller)
    {
        ExecuteActions(controller);
        EvaluateTransitions(controller);
    }
    
    /// <summary>
    /// Calls all Acts methods
    /// </summary>
    /// <param name="controller"></param>
    public void ExecuteActions(StateController controller)
    {
        foreach (AIAction action in Actions)
        {
            action.Act(controller);
        }
    }

    /// <summary>
    /// Checks every frame if we met certain condition in order to transition to another state
    /// </summary>
    /// <param name="controller"></param>
    public void EvaluateTransitions(StateController controller)
    {
        if (Transitions != null || Transitions.Length > 0)
        {
            for (int i = 0; i < Transitions.Length; i++)
            {
                bool decisionValue = Transitions[i].Decision.Decide(controller);
                if (decisionValue)
                {
                    controller.TransitionToState(Transitions[i].TrueState);
                }
                else
                {
                    controller.TransitionToState(Transitions[i].FalseState);
                }
            }
        }
    }
}

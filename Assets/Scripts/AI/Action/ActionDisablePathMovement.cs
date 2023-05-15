using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Action Disable Path Movement", fileName = "ActionDisablePathMovement")]
public class ActionDisablePathMovement : AIAction
{
    public override void Act(StateController controller)
    {
        DisablePath(controller);
    }

    /// <summary>
    /// Disable the path component attached to the object
    /// </summary>
    /// <param name="controller"></param>
    private void DisablePath(StateController controller)
    {
        if (controller.Target != null)
        {
            controller.Path.enabled = false;
        }
    }
}

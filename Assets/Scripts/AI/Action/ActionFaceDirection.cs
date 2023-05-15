using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Action Face Direction", fileName = "ActionFaceDirection")]
public class ActionFaceDirection : AIAction
{
    public override void Act(StateController controller)
    {
        FaceDirection(controller);
    }

    /// <summary>
    /// Makes face the direction of our movement
    /// </summary>
    /// <param name="controller"></param>
    private void FaceDirection(StateController controller)
    {
        if (controller.Path != null)
        {
            if (controller.Path.Direction == PathFollow.MoveDirections.RIGHT)
            {
                controller.transform.localScale = new Vector3(1,1,1);
            }
            else
            {
                controller.transform.localScale = new Vector3(-1,1,1);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Tilia.Locomotors.AxisMove;
using UnityEngine;
using UnityEngine.Events;

public class StandUpPositionHandler : MonoBehaviour
{
    bool sitting = false;
    [SerializeField] Transform cameraRig;
    [SerializeField] UnityEvent standUpTeleportEvent;
    [SerializeField] AxisMoveFacade movementHandler;
    float horizontalMovementMultiplier;
    float verticalMovementMultiplier;
    public void SetPosition()
    {
        if (sitting)
            return;
        transform.position = cameraRig.position;
        sitting = true;
        horizontalMovementMultiplier = movementHandler.HorizontalAxisMultiplier;
        verticalMovementMultiplier = movementHandler.VerticalAxisMultiplier;
        movementHandler.HorizontalAxisMultiplier = 0;
        movementHandler.VerticalAxisMultiplier = 0;
    }

    public void StandUp()
    {
        if (!sitting)
            return;
        sitting = false;
        standUpTeleportEvent.Invoke();
        movementHandler.HorizontalAxisMultiplier = horizontalMovementMultiplier;
        movementHandler.VerticalAxisMultiplier = verticalMovementMultiplier;
    }
}

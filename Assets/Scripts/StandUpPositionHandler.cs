using System.Collections;
using System.Collections.Generic;
using Tilia.Locomotors.AxisMove;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class StandUpPositionHandler : MonoBehaviour
{
    bool sitting = false;
    [SerializeField] Transform cameraRig;
    [SerializeField] UnityEvent standUpTeleportEvent;
    [SerializeField] AxisMoveFacade movementHandler;
    [SerializeField] GameObject tablet;
    [SerializeField] TMP_Text tabletText;
    Keyboard keyboard;
    bool tabletOn = false;

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

    public void TabletInput() {
        if (!sitting)
            return;
        if (!keyboard)
            keyboard = FindObjectOfType<Keyboard>();
        if (!tabletOn)
            OpenTablet();
        else
            CloseTablet();
    }

    void OpenTablet()
    {            
        keyboard.gameObject.SetActive(true);
        keyboard.Edit(tabletText);
        tablet.SetActive(true);
        tabletOn = true;
    }

    void CloseTablet() {
        keyboard.gameObject.SetActive(false);
        tablet.SetActive(false);
        tabletOn = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SmoothTurnProvider : LocomotionProvider
{
    // How much do we turn?
    public float turnSegment = 45.0f;
    // How long does it take to turn?
    public float turnTime = 3.0f;
    // Basic input - I'd recommend replacing with an input solution.
    public InputHelpers.Button rightTurnButton = InputHelpers.Button.PrimaryAxis2DRight;
    public InputHelpers.Button leftTurnButton  = InputHelpers.Button.PrimaryAxis2DLeft;
    
    // List of the controllers we're going to use
    public List<XRController> controllers = new List<XRController>();
    // The amount we're turning to
    private float targetTurnAmount = 0.0f;
    private void Update()
    {
        // Let's ask the locomotion system if we can move
        if (CanBeginLocomotion())
        {
            CheckForInput();
        }
    }

    private void CheckForInput()
    {
        foreach (XRController controller in controllers)
        {
            targetTurnAmount = CheckForTurn(controller);

            if (targetTurnAmount != 0.0f)
            {
                TrySmoothTurn();
            }
        }
    } 

    // Check for input, this can be done cleaner with a more robust input solution
    private float CheckForTurn(XRController controller)
    {
        // Check if we pressed right
        if (controller.inputDevice.IsPressed(rightTurnButton,out bool rightPress))
        {
            if (rightPress)
            {
                return turnSegment;
            }
        }
        if (controller.inputDevice.IsPressed(leftTurnButton,out bool leftPress))
        {
            if (leftPress)
            {
                return -turnSegment;
            }
        }
        // Check if we pressed left

        // If we hit nothing return 0
        return 0.0f;
    }

    private void TrySmoothTurn()
    {
        // Let's stry turning with the amount we got
        StartCoroutine(TurnRoutine(targetTurnAmount));
        // Since the value has been used, let's clear it out
        targetTurnAmount = 0.0f;
    }

    private IEnumerator TurnRoutine(float turnAmount)
    {
        // We need to store this since we only want to pass the difference
        float previousTurnChange = 0.0f;
        // Record the whole time of the loop for proper lerp
        float elapsedTime = 0.0f;
        // Let the motion begin
        BeginLocomotion();
        // How far are we into the lerp?
        while (elapsedTime<=turnTime)
        {
            float blend = elapsedTime/turnTime;
            float turnChange = Mathf.Lerp(0,turnAmount,blend);

            float turnDifference = turnChange - previousTurnChange;
            system.xrOrigin.RotateAroundCameraUsingOriginUp(turnDifference);
            previousTurnChange = turnChange;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        EndLocomotion();

        // Let the motion end
    }
}

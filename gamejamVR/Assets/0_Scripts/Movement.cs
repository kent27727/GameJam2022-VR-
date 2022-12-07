using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Movement : LocomotionProvider
{
    public List<XRController> controllers = null;
    public float speed;
    public float gravityMultiplier;
    private CharacterController characterController = null;
    public GameObject head;
    public GameObject testOBJ;
    protected override void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        PositionController();
    }

    private void FixedUpdate()
    {
        PositionController();
        CheckForInput();
        ApplyGravity();
    }

    private void PositionController()
    {

        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);

        Vector3 newCenter = Vector3.zero;
        newCenter.y -= characterController.height / 2;
        newCenter.y += characterController.skinWidth;

        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;

        // characterController.center = newCenter;
    }

    private void CheckForInput()
    {
        foreach (XRController item in controllers)
        {
            if (item.enableInputActions)
            {
                CheckForMovement(item.inputDevice);
            }
        }
    }

    private void CheckForMovement(InputDevice device)
    {
        
        
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 positon))
        {
            StartMove(positon);
        }
    }

    private void StartMove(Vector2 position)
    {
        // Apply the touch position to the head's forward Vector
        Vector3 direction = new Vector3(position.x, 0, position.y);
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);
        // Rotate the input direction by the horizontal head rotation
        direction = Quaternion. Euler(headRotation) * direction;
        // Apply speed and move
        Vector3 movement = direction * speed;
        characterController.Move(movement * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
        gravity.y *= Time.deltaTime;
        characterController.Move(gravity * Time.deltaTime);

    }
}

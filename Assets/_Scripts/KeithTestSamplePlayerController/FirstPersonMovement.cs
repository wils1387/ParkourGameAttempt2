using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    private InputManager inputManager;
    private Vector2 inputs;

    public float baseSpeed = 5;

    private CharacterController characterController;

    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    private float yVelocity;
    public float targetYVelocity;

    private void Start()
    {
        Awake();
        yVelocity = 0;
        inputs = Vector2.zero;
    }

    void Awake()
    {
        // Get the rigidbody on this.
        inputManager = InputManager.instance;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        inputs = new Vector2(inputManager.horizontalMoveAxis, inputManager.verticalMoveAxis);
        yVelocity = targetYVelocity; //this doesn't feel correct in gameplay but makes sense for physics, perfect example of why we're doing custom physics, want austin to tweek this tho
        Vector3 targetVelocity = transform.right * inputs.x * baseSpeed * Time.deltaTime +
            Vector3.up * yVelocity +
            transform.forward * inputs.y * baseSpeed * Time.deltaTime;

        characterController.Move(targetVelocity);
    }
}
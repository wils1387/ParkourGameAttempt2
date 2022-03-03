using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    private InputManager inputManager;
    private Vector2 inputs;

    public float baseSpeed = 5;

    private CharacterController characterController;

    /// <summary> Time modifier expires, speed value. Functions to override movement speed. Will use the last added override. </summary>
    public List<Vector2> speedOverrides = new List<Vector2>();

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
        UpdateSpeedOverrides();
        float speed = (speedOverrides.Count > 0) ? speedOverrides[-1].y : baseSpeed;
        Vector3 targetVelocity = transform.right * inputs.x * speed * Time.deltaTime +
            Vector3.up * yVelocity +
            transform.forward * inputs.y * speed * Time.deltaTime;

        characterController.Move(targetVelocity);
    }

    void UpdateSpeedOverrides()
    {
        for (int i = 0; i < speedOverrides.Count-1; i++)
        {
            if (Time.time > speedOverrides[i].x) speedOverrides.RemoveAt(i);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerGroundedJump : MonoBehaviour
{
    private InputManager inputManager;
    private FirstPersonMovement fpsMotor;
    private GroundCheck groundCheck;

    [Range(0,100)]
    public int value = 10; //initial y velocity for jump

    // Start is called before the first frame update
    void Start()
    {
        Awake();
    }

    private void Awake()
    {
        fpsMotor = GetComponent<FirstPersonMovement>();
        groundCheck = GetComponentInChildren<GroundCheck>();
        inputManager = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.jumpPressed && groundCheck.isGrounded) fpsMotor.targetYVelocity = value/100f;
    }
}

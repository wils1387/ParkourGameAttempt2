using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerSlide : MonoBehaviour
{
    private InputManager inputManager;
    private FirstPersonMovement fpsMotor;
    private GroundCheck groundCheck;

    [Range(0.0f,90.0f)]
    public float slideAngle = 15f;

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
        if (inputManager.crouchPressed && groundCheck.isGrounded)
        {

        }
    }
}

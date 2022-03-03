using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerCrouch : MonoBehaviour
{
    private InputManager inputManager;
    private FirstPersonMovement fpsMotor;
    private GroundCheck groundCheck;

    public float crouchSpeed;

    public float totalCrouchTime;
    public float crouchCoolDown;

    private float timeCrouchStart;

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
        timeCrouchStart = -crouchCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.crouchPressed && groundCheck.isGrounded && Time.time > timeCrouchStart + crouchCoolDown)
        {
            fpsMotor.speedOverrides.Add(new Vector2(Time.time + totalCrouchTime, crouchSpeed));
            fpsMotor.gameObject.transform.localScale =Vector3.one - Vector3.up * .5f;
            timeCrouchStart = Time.time;
        }
        if (Time.time > timeCrouchStart + totalCrouchTime)
        {
            fpsMotor.gameObject.transform.localScale = Vector3.one;
        }
    }
}

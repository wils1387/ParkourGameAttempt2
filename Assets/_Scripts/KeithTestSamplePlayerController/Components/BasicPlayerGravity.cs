using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerGravity : MonoBehaviour
{
    private FirstPersonMovement fpsMotor;
    private GroundCheck groundCheck;

    [Range(-10.0f,10.0f)]
    public float value = -9.81f;
    public float terminalVelocityValue = 30f;
    // Start is called before the first frame update
    void Start()
    {
        Awake();
    }

    private void Awake()
    {
        fpsMotor = GetComponent<FirstPersonMovement>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Update()
    {
        if (!groundCheck.isGrounded && Mathf.Abs(fpsMotor.targetYVelocity) < terminalVelocityValue) fpsMotor.targetYVelocity += value * Time.deltaTime;
        if (groundCheck.isGrounded && fpsMotor.targetYVelocity < -0.001f) fpsMotor.targetYVelocity = Mathf.Lerp(fpsMotor.targetYVelocity, 0, Time.deltaTime);
    }
}

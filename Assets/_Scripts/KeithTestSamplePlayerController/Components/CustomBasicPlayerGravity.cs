using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UIElements;

public class CustomBasicPlayerGravity : MonoBehaviour
{
    private FirstPersonMovement fpsMotor;
    private GroundCheck groundCheck;

    public List<GravityField> gravityFields;

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
        if (!groundCheck.isGrounded && Mathf.Abs(fpsMotor.targetYVelocity) < terminalVelocityValue)
        {
            foreach (GravityField gravityField in gravityFields)
            {
                if (fpsMotor.targetYVelocity > gravityField.min && fpsMotor.targetYVelocity <= gravityField.max)
                {
                    fpsMotor.targetYVelocity += gravityField.value * Time.deltaTime;
                }
            }
        }
        if (groundCheck.isGrounded && fpsMotor.targetYVelocity < -0.001f) fpsMotor.targetYVelocity = Mathf.Lerp(fpsMotor.targetYVelocity, 0, Time.deltaTime);
    }
}

[Serializable]
public struct GravityField
{
    [Tooltip("Exclusive")]
    public float min;
    [Tooltip("Inclusive")]
    public float max;

    [Range(0,-3f)]
    public float value;
}
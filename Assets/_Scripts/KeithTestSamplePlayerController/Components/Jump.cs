using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpStrength = 2;
    public event System.Action Jumped;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;

    private InputManager inputManager;

    private void Start()
    {
        Awake();
    }

    void Reset()
    {
        // Try to get groundCheck.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        // Get the rigidbody on this.
        inputManager = InputManager.instance;
        
    }

    void LateUpdate()
    {
        // Jump when the Jump button is pressed and we are on the ground.
        if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
        {
            Jumped?.Invoke();
        }
    }
}

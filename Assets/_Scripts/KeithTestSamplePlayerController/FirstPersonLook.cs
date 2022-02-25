using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField]
    Transform character;
    public float sensitivity = 5;

    private Vector2 velocity;

    private void Awake()
    {
        inputManager = InputManager.instance;

    }

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
        Awake();
    }

    void Update()
    {
        Vector2 mouseDelta = new Vector2(inputManager.horizontalLookAxis,
            inputManager.verticalLookAxis);
        velocity += mouseDelta * (sensitivity / 100);
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }
}

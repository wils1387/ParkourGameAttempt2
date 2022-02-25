using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPerpendicularFromGround : MonoBehaviour
{
    private GroundCheck groundCheck;
    private FirstPersonMovement fpsMotor;

    [Header("Box Casting")]
    public List<string> whitelistTags;
    public Vector3 boxCastScale;
    public float maxBoxCastDistance = 1000f;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        Awake();
    }

    private void Awake()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        fpsMotor = GetComponent<FirstPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        bool hitDetect = Physics.BoxCast(groundCheck.transform.position, boxCastScale, -transform.up, out hit, transform.rotation, maxBoxCastDistance);
        if (hitDetect)
        {
            foreach (string tag in whitelistTags)
            {
                if (hit.collider.CompareTag(tag))
                {
                    Debug.Log("make the player perpendicular to " + hit.normal + " from " + hit.collider.gameObject.name);
                }
            }
        }
    }
}

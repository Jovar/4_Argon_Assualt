using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [SerializeField] [Tooltip("In ms^-1")] float xSpeed = 10f;
    [SerializeField] [Tooltip("In m")] float xRange = 5f;

    [SerializeField] [Tooltip("In ms^-1")] float ySpeed = 10f;
    [SerializeField] [Tooltip("In m")] float yRange = 3f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -30f;

    [SerializeField] float positionYawFactor = 5f;

    [SerializeField] float controlRollFactor = -15f;

    float xThrow, yThrow;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        // movement of the ship's position
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        float xOffset = (xThrow * xSpeed) * Time.deltaTime;
        float xPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = (yThrow * ySpeed) * Time.deltaTime;
        float yPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {

        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Cmr : MonoBehaviour {

    private const float Y_ANGLE_MIN = -50.0f;
    private const float Y_ANGLE_MAX = 10.0f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 2.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float curX = 0.0f;
    private float curY = 0.0f;
    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;

	// Use this for initialization
	private void Start () {
        camTransform = transform;
        cam = Camera.main;
	}

    private void Update()
    {
        currentX += CrossPlatformInputManager.GetAxis("Ho");
        currentY += CrossPlatformInputManager.GetAxis("Ve");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        curX += CrossPlatformInputManager.GetAxis("Hor");
        curY += CrossPlatformInputManager.GetAxis("Ver");

        curY = Mathf.Clamp(curY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    // Update is called once per frame
    private void LateUpdate () {
        if (CrossPlatformInputManager.GetAxis("Ho") > 0 || CrossPlatformInputManager.GetAxis("Ve") > 0)
        {
            Vector3 dir = new Vector3(0.4f, 0, -distance);
            Quaternion rotation = Quaternion.Euler(-currentY * 5, currentX * 5, 0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position);
        }

        if(CrossPlatformInputManager.GetAxis("Hor") > 0 || CrossPlatformInputManager.GetAxis("Ver") > 0)
        {
            Vector3 direction = new Vector3(0.4f, 0, -distance);
            Quaternion rot = Quaternion.Euler(-curY * 5, curX * 5, 0);
            camTransform.position = lookAt.position + rot * direction;
            camTransform.LookAt(lookAt.position);
        }
    }
}

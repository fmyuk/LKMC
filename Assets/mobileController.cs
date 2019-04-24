using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.CrossPlatformInput;

public class mobileController : MonoBehaviour {

    private CharacterController charaCon;
    private Animator animator;
    public float speed = 5.0f;
    public float rotate = 1200.0f;

    private const string key_isRun = "IsRun";

    // Use this for initialization
    void Start () {
        charaCon = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(CrossPlatformInputManager.GetAxis("Vertical") == 0 && CrossPlatformInputManager.GetAxis("Horizontal") == 0)
        {
            animator.SetBool(key_isRun, false);
        }
        else
        {
            var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 direction = cameraForward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizontal");
            animator.SetBool(key_isRun, true);

            Direction(direction);
            Speed(direction);
        }
    }

    void Direction(Vector3 dir)
    {
        Quaternion q = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotate * Time.deltaTime);
    }

    void Speed(Vector3 length)
    {
        charaCon.Move(length * Time.deltaTime * speed);
    }
}

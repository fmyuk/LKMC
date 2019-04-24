using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public GameObject Player;
    public GameObject Camera;
    public float speed;
    private Transform PlayerTransform;
    public SampleAnimation sa;
    //private Transform CameraTransform;
    private CharacterController charaCon;

    [Range(-0.999f,-0.5f)]
    public float minYAngle = -0.5f;
    [Range(0.5f,0.999f)]
    public float maxYAngle = 0.5f;

	// Use this for initialization
	void Start () {
        PlayerTransform = transform.parent;
        //CameraTransform = GetComponent<Transform>();
        charaCon = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        float X_Rotation = CrossPlatformInputManager.GetAxis("Ho");
        float Y_Rotation = CrossPlatformInputManager.GetAxis("Ve");
        PlayerTransform.transform.Rotate(0, X_Rotation * 5, 0);

        float X_Rot = CrossPlatformInputManager.GetAxis("Hor");
        float Y_Rot = CrossPlatformInputManager.GetAxis("Ver");
        PlayerTransform.transform.Rotate(0, X_Rot * 5, 0);
        //CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);

        //float nowAngle = Camera.transform.localRotation.x;

        //if(Y_Rotation != 0)
        //{
        //    if(0 < Y_Rotation)
        //    {
        //        if(minYAngle <= nowAngle)
        //        {
        //            CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
        //        }
        //    }
        //    else
        //    {
        //        if(nowAngle <= maxYAngle)
        //        {
        //            CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
        //        }
        //    }
        //}
        //CameraTransform.eulerAngles = new Vector3(CameraTransform.eulerAngles.x, CameraTransform.eulerAngles.y, 0f);

        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));

        if (Input.GetKey(KeyCode.W) && sa.hp > 0)
        {
            PlayerTransform.transform.position += dir1 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && sa.hp > 0)
        {
            PlayerTransform.transform.position += dir2 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && sa.hp > 0)
        {
            PlayerTransform.transform.position += -dir2 * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && sa.hp > 0)
        {
            PlayerTransform.transform.position += -dir1 * speed * Time.deltaTime;
        }
    }
}

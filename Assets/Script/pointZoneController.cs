using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointZoneController : MonoBehaviour {

    private float point = 0.0f;
    private GameObject points;

	// Use this for initialization
	void Start () {
        float point = 0.0f;
        this.points = GameObject.Find("point");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            point += Time.deltaTime;
            this.points.GetComponent<Text>().text = "Point: " + point.ToString("F2") + "pt";
        }
    }
}

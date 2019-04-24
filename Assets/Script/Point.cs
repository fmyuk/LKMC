using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour {

    public GameObject zombie;
    Text point;
    public int kill = 0;

    // Use this for initialization
    void Start () {
        zombie = GameObject.Find("ZombiePrefab");
        point = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        this.point.text = kill.ToString() + " KILL";
    }

    public void AddPoint(int value)
    {
        kill += value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;
    [SerializeField] private float rotateSpeed = 45f;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(target.position);

        //if(state == EnemyState.Walk || state == EnemyState.Chase)
	}
}

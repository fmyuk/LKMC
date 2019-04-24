using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class SearchFujimi : MonoBehaviour {

    public bool isActive = false;

    [SerializeField] Transform target;

    UnityEngine.AI.NavMeshAgent agent;
    ThirdPersonCharacter character;

    Fujimi hp;

    private Animator animator;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();

        agent.updateRotation = false;
        agent.updatePosition = true;

        animator = GetComponent<Animator>();
        hp = GetComponent<Fujimi>();
    }

    private void Update()
    {
        if (isActive)
        {
            agent.isStopped = false;

            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
            {
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }
        }
        else
        {
            character.Move(Vector3.zero, false, false);
            agent.isStopped = true;

            return;
        }

    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("ゲームオーバーです。");
            //isActive = false;
            animator.SetBool("Attack 0", true);
        }
        if (hp.currentHealth <= 0)
        {
            isActive = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isActive = true;
        }
        if (hp.currentHealth <= 0)
        {
            isActive = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isActive = false;
            animator.SetBool("Attack 0", false);
        }
    }
}

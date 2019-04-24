using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fujimi : MonoBehaviour {

    public bool canDie = true;

    public float startingHealth = 100.0f;
    public float maxHealth = 100.0f;
    public float currentHealth;

    public bool replaceWhenDead = false;
    public GameObject deadReplacement;
    public bool makeExplosion = false;
    public GameObject explosion;

    public bool isPlayer = false;
    public GameObject deathCam;

    private bool dead = false;
    private Animator animator;
    private bool Death = false;

    public float timeOut = 10.0f;
    public float time = 0.0f;



    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        float time = 0f;
        InvokeRepeating("Revive", 10, 10);
        Death = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;

        if (currentHealth <= 0 && !dead && canDie)
        {
            Die();

        }
        else if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void Revive()
    {
        animator.SetBool("Death", false);
        currentHealth = startingHealth;
    }

    public void Die()
    {
        //dead = true;

        //if (replaceWhenDead)
        //    Instantiate(deadReplacement, transform.position, transform.rotation);
        //if (makeExplosion)
        //    Instantiate(explosion, transform.position, transform.rotation);

        //if (isPlayer && deathCam != null)
            //deathCam.SetActive(true);

        animator.SetBool("Death", true);

        //Destroy(gameObject);

    }
}

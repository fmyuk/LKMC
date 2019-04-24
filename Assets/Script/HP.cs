using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour {

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

    private ZombieGenerator zombieGen;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        InvokeRepeating("Revive", 10, 10);
        Death = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;

        if(currentHealth <= 0 && !dead && canDie)
        {
            Die();

        } else if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void Revive()
    {
        animator.SetBool("Death", false);
        currentHealth = startingHealth;
    }

    public void setZombieGenerator(ZombieGenerator zombieGen)
    {
        this.zombieGen = zombieGen;
    }

    public void Die()
    {
        dead = true;

        if (replaceWhenDead)
            Instantiate(deadReplacement, transform.position, transform.rotation);
        if (makeExplosion)
            Instantiate(explosion, transform.position, transform.rotation);

        if (isPlayer && deathCam != null)
        deathCam.SetActive(true);

        animator.SetBool("Death", true);

        Destroy(gameObject);

        GameObject pointObj = GameObject.Find("point");
        Point point = pointObj.GetComponent<Point>();
        point.AddPoint(1);

        zombieGen.DecreaseZombieNum();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour {

    [SerializeField] GameObject[] enemys;
    [SerializeField] float appearNextTime;
    [SerializeField] int maxNumOfEnemys;
    private int numberOfEnemies;
    private float elapsedTime;

    void Start()
    {
        numberOfEnemies = 0;
        elapsedTime = 0f;
    }

    void Update()
    {
        if(numberOfEnemies >= maxNumOfEnemys)
        {
            return;
        }
        else
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > appearNextTime)
            {
                elapsedTime = 0f;
                AppearEnemy();
            }
        }
    }

    void AppearEnemy()
    {
        var randomValue = Random.Range(0, enemys.Length);
        var randomRotationY = Random.value * 360f;

        GameObject obj = Instantiate(enemys[randomValue], transform.position, Quaternion.Euler(0f, randomRotationY, 0f));

        HP enemyHp = obj.GetComponent<HP>();
        enemyHp.setZombieGenerator(this);

        numberOfEnemies++;
        elapsedTime = 0f;
    }

    public void DecreaseZombieNum()
    {
        numberOfEnemies--;
    }
}

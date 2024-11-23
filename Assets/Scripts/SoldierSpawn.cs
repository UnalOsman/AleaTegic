using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawn : MonoBehaviour
{
    public int health = 100;
    public int attackPower = 10;

    public int goldCost = 50;

    private Castle enemyCastle;
    public float moveSpeed = 2.0f;
    public float attackSpeed = 1;

    private void Start()
    {
        enemyCastle = FindObjectOfType<Castle>();
    }

    private void Update()
    {
        MoveTowardsCastle();
    }


    private void MoveTowardsCastle()
    {
        if (enemyCastle != null)
        {
            float stopDistance = 25f;

            Vector3 directionToCastle=(enemyCastle.transform.position - transform.position).normalized;

            Vector3 targetPosition=new Vector3
            (enemyCastle.transform.position.x - directionToCastle.x * stopDistance,transform.position.y,enemyCastle.transform.position.z);
            float distanceToTarget=Vector3.Distance(transform.position, targetPosition);

            if(distanceToTarget >0.1f)
            {
                Vector3 direction = (targetPosition - transform.position).normalized;

                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else
            {
                AttackCastle();
            }
            
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void AttackCastle()
    {
        if(enemyCastle != null)
        {
            enemyCastle.TakeDamage(attackPower,attackSpeed);
        }
    }


    /*
    public List<SoldierSO> soldierSoList;

    private string soldierName;
    private int attackValue;
    private int health;
    private int maxHealth;
    private int minHealth;
    private int GoldValue;
    private int featureValue;
    private float attackSpeed;

    public void SoldierSpawning()
    {
        

        soldierName = soldierSo.soldierName;
        attackValue = soldierSo.attackValue;
        health = soldierSo.health;
        maxHealth = soldierSo.maxHealth;
        minHealth = soldierSo.minHealth;
        attackSpeed = soldierSo.attackSpeed;
        GoldValue = soldierSo.GoldValue;
        soldierSo.featureValue = Random.Range(1, 5);
        featureValue = soldierSo.featureValue;
        attackValue *= featureValue;

        if (soldierSo.soldierName=="Soldier")
        {
            Debug.Log("Attack value : " + attackValue);
            Debug.Log("Feature value : " + featureValue);
        }
    }

    public void SpearmanSpawning()
    {
        soldierName = soldierSo.soldierName;
        attackValue = soldierSo.attackValue;
        health = soldierSo.health;
        maxHealth = soldierSo.maxHealth;
        minHealth = soldierSo.minHealth;
        attackSpeed = soldierSo.attackSpeed;
        GoldValue = soldierSo.GoldValue;
        soldierSo.featureValue = Random.Range(1, 5);
        featureValue = soldierSo.featureValue;
        attackValue *= featureValue;

        if (soldierSo.soldierName == "Spearman")
        {
            Debug.Log("Attack value : " + attackValue);
            Debug.Log("Feature value : " + featureValue);
        }
    }
    */
}

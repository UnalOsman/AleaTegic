using UnityEngine;

public class SoldierSpawn : MonoBehaviour
{
    public SoldierSO soldierSo;

    private string soldierName;
    private int attackValue;
    private int health;
    private int maxHealth;
    private int minHealth;
    private int GoldValue;
    private int featureValue;
    private float attackSpeed;

    private void Start()
    {
        soldierName = soldierSo.soldierName;
        attackValue = soldierSo.attackValue;
        health = soldierSo.health;
        maxHealth = soldierSo.maxHealth;
        minHealth = soldierSo.minHealth;
        attackSpeed = soldierSo.attackSpeed;
        GoldValue = soldierSo.GoldValue;
        soldierSo.featureValue=Random.Range(1, 5);
        featureValue = soldierSo.featureValue;
        attackValue *= featureValue;
    }


    public void SoldierSpawning()
    {
        if(soldierSo.soldierName=="Soldier")
        {
            Debug.Log("Attack value : " + attackValue);
            Debug.Log("Feature value : " + featureValue);
        }
        
    }
}

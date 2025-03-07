using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnerManager : MonoBehaviour
{
    [SerializeField] protected List<SoldierSO> allSoldiers = new List<SoldierSO>();
     
    
    [SerializeField] public Transform targetCastle;
    [SerializeField] protected Transform spawnPoint;

    [Header("References")]
    public GoldManager goldManager;


    public void SpawnSoldier(SoldierSO selectedSoldier)
    {
        if(goldManager.SpendGold(selectedSoldier.GoldCost))
        {
            float minZ = -8f;
            float maxZ = 8f;

            float randomZ = Random.Range(minZ, maxZ);

            Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, randomZ);

            GameObject newSoldier =Instantiate(selectedSoldier.soldierPrefab, spawnPosition,Quaternion.identity);
            Unit soldierUnit=newSoldier.GetComponent<Unit>();

            soldierUnit.health = selectedSoldier.health;
            soldierUnit.maxHealth = selectedSoldier.maxHealth;
            soldierUnit.minHealth = selectedSoldier.minHealth;
            soldierUnit.attackPower = selectedSoldier.attackPower;
            soldierUnit.attackSpeed = selectedSoldier.attackSpeed;
            soldierUnit.moveSpeed = selectedSoldier.moveSpeed;
            soldierUnit.GoldCost = selectedSoldier.GoldCost;
            selectedSoldier.featureValue = Random.Range(1, 5);
            soldierUnit.featureValue = selectedSoldier.featureValue;
            soldierUnit.attackPower *= selectedSoldier.featureValue;
            soldierUnit.attackRange = selectedSoldier.attackRange;

            soldierUnit.SetTarget(targetCastle);

            if(this is SoldierSpawnManager)
            {
                newSoldier.tag = "Player";
            }
            else if(this is EnemySpawner)
            {
                newSoldier.tag = "Enemy";
            }
        }
    }
}

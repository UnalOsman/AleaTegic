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
            float minZ = -4f;
            float maxZ = 4f;

            float randomZ = Random.Range(minZ, maxZ);

            Vector3 spawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, randomZ);

            GameObject newSoldier =Instantiate(selectedSoldier.soldierPrefab, spawnPosition,Quaternion.identity);
            Unit soldierUnit=newSoldier.GetComponent<Unit>();
            UnitMovement soldierMovement = newSoldier.GetComponent<UnitMovement>();
            UnitCombat soldierCombat = newSoldier.GetComponent<UnitCombat>();

            soldierUnit.health = selectedSoldier.health;
            soldierUnit.minHealth = selectedSoldier.minHealth;
            soldierUnit.maxHealth = selectedSoldier.maxHealth;
            soldierUnit.goldCost = selectedSoldier.GoldCost;
            selectedSoldier.featureValue = Random.Range(1, 5);
            soldierUnit.featureValue = selectedSoldier.featureValue;

            soldierCombat.attackRange = selectedSoldier.attackRange;
            soldierCombat.attackSpeed = selectedSoldier.attackSpeed;
            soldierCombat.attackPower = selectedSoldier.attackPower;
            soldierCombat.attackPower *= selectedSoldier.featureValue;

            soldierMovement.moveSpeed = selectedSoldier.moveSpeed;

            if(targetCastle == null)
            {
                Debug.LogError(gameObject.name + " i�in targetCastle NULL! L�tfen Inspector'dan ayarla.");
            }
            else
            {
                soldierMovement.SetTarget(targetCastle);
            }
            

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

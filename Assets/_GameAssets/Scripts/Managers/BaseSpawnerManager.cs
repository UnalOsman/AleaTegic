using System.Collections.Generic;
using UnityEngine;

public class BaseSpawnerManager : MonoBehaviour
{
    [SerializeField] protected List<SoldierSO> allSoldiers = new List<SoldierSO>();
     
    
    [SerializeField] public Transform targetCastle;
    [SerializeField] protected Transform Spawner;

    [Header("References")]
    public GoldManager goldManager;


    public void SpawnSoldier(SoldierSO selectedSoldier)
    {

        if (goldManager.SpendGold(selectedSoldier.GoldCost))
        {
            float minZ = 31f;
            float maxZ = 40f;

            float randomZ = Random.Range(minZ, maxZ);


            GameObject newSoldier =Instantiate(selectedSoldier.soldierPrefab, new Vector3(Spawner.position.x, Spawner.position.y, randomZ),Quaternion.identity);
            Debug.Log("Spawnlanan karakter pozisyonu: " + newSoldier.transform.position);
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
            if(targetCastle != null)
            {
                soldierMovement.SetTarget(targetCastle);
                soldierCombat.SetTarget(targetCastle.GetComponent<Castle>());
                soldierUnit.currentTargetCastle = targetCastle;
            }
            
            if (this is SoldierSpawnManager)
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

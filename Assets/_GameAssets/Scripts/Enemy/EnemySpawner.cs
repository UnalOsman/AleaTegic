using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BaseSpawnerManager
{
    [SerializeField] private GameObject enemyCastle;
    public float spawnInterval = 2.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemySoldier), spawnInterval, spawnInterval);
    }

    private void SpawnEnemySoldier()
    {
        List<SoldierSO> affordableSoldiers = allSoldiers.FindAll(s => s.GoldCost <= goldManager.currentGold);
        if(affordableSoldiers.Count > 0 && enemyCastle!=null)
        {
            SoldierSO soldier= affordableSoldiers[Random.Range(0,affordableSoldiers.Count)];
            
            SpawnSoldier(soldier);
        }
        else
        {
            Debug.Log("Düþman, asker çýkaramýyor! Yeterli altýn yok!!");
        }
    }
}

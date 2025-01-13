using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<SoldierSO> allSoldiers=new List<SoldierSO>();

    public Transform targetCastle;
    public Transform spawnPoint;

    public GoldManager goldManager;
    public float spawnInterval = 5.0f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemySoldier), spawnInterval, spawnInterval);
    }

    private void SpawnEnemySoldier()
    {
        List<SoldierSO> affordableSoldiers= allSoldiers.FindAll(s => s.GoldCost <= goldManager.currentGold);

        if(affordableSoldiers.Count > 0 )
        {
            SoldierSO selectedSoldier = affordableSoldiers[Random.Range(0,affordableSoldiers.Count)];

            if(goldManager.SpendGold(selectedSoldier.GoldCost))
            {
                GameObject newSoldier = Instantiate(selectedSoldier.soldierPrefab,spawnPoint.position,Quaternion.identity);
                Unit soldierUnit= newSoldier.GetComponent<Unit>();
                soldierUnit.SetTarget(targetCastle);
                Debug.Log("Düþman oluþturuldu!");
            }
            Debug.Log("Düþman seçildi!");
        }
        Debug.Log("Düþman listesi oluþturuldu!");
    }
}

using UnityEngine;

public class SoldierSpawnManager : BaseSpawnerManager
{
    [SerializeField] private GameObject playerCastle;

    private void Awake()
    {
        GameObject enemyCastleObj = GameObject.FindGameObjectWithTag("EnemyCastle");
        if (enemyCastleObj != null)
        {
            targetCastle = enemyCastleObj.transform;
        }
        else
        {
            Debug.LogError("EnemyCastle sahnede bulunamadý!");
        }
    }
    public void SpawnSoldierByIndex(int index)
    {
        if(index >=0 && allSoldiers.Count > 0 && targetCastle != null && playerCastle!=null)
        {
            SoldierSO soldier = allSoldiers[index];
            
            SpawnSoldier(soldier);

        }
        else
        {
            Debug.LogWarning("Geçersiz asker türü indeksi!!");
        }
    }
}

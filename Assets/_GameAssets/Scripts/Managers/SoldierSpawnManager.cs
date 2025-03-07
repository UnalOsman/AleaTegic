using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoldierSpawnManager : BaseSpawnerManager
{
    [SerializeField] private GameObject playerCastle;
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

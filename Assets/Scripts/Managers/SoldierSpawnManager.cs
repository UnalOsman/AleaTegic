using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawnManager : BaseSpawnerManager
{
   public void SpawnSoldierByIndex(int index)
    {
        if(index >=0 && allSoldiers.Count > 0 && targetCastle != null)
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

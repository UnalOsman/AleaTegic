using UnityEngine;
using UnityEngine.UI;

public class SoldierButton : MonoBehaviour
{
    public SoldierSpawnManager spawnerManager;
    public int soldierIndex;


     void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=> spawnerManager.SpawnSoldier(soldierIndex));
    }

}

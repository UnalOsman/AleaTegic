using UnityEngine;
using UnityEngine.UI;

public class SoldierButton : MonoBehaviour
{
    public SoldierSpawnManager spawnerManager;
    [SerializeField] private int soldierIndex;


     void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=> spawnerManager.SpawnSoldierByIndex(soldierIndex));
    }

}

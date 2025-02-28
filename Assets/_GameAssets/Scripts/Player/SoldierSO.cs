using UnityEngine;

[CreateAssetMenu(fileName = "SoldierSO", menuName = "Scriptable Objects/SoldierSO")]
public class SoldierSO : ScriptableObject
{
    public string soldierName;
    public GameObject soldierPrefab;
    public int attackPower;
    public int health;
    public int maxHealth;
    public int minHealth;
    public int GoldCost;
    public int featureValue;
    public float attackSpeed;
    public float moveSpeed;
    public float attackRange;

}

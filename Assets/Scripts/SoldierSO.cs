using UnityEngine;

[CreateAssetMenu(fileName = "SoldierSO", menuName = "Scriptable Objects/SoldierSO")]
public class SoldierSO : ScriptableObject
{
    public string soldierName;
    public int attackValue;
    public int health;
    public int maxHealth;
    public int minHealth;
    public int GoldValue;
    public int featureValue;
    public float attackSpeed;

}

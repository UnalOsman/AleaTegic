using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public int currentGold = 50;
    public int incomeRate = 5; // zamanla gelen altýn deðeri
    public float incomeInterval = 3.0f; // altýn geliri zaman aralýðý

    private void Start()
    {
        InvokeRepeating(nameof(AddIncome),incomeInterval,incomeInterval);
    }

    private void AddIncome()
    {
        currentGold += incomeRate;
        Debug.Log("Þuanki altýn deðeri : " + currentGold);
    }

    public bool SpendGold(int gold)
    {
        if(currentGold >= gold)
        {
            currentGold -= gold;
            return true;
        }
        else
        {
            Debug.LogWarning("Yeterli altýn yok!");
            return false;
        }
    }
}

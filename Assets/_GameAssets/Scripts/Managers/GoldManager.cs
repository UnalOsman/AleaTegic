using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public int currentGold = 50;
    public int incomeRate = 5; // zamanla gelen alt�n de�eri
    public float incomeInterval = 3.0f; // alt�n geliri zaman aral���

    private void Start()
    {
        InvokeRepeating(nameof(AddIncome),incomeInterval,incomeInterval);
    }

    private void AddIncome()
    {
        currentGold += incomeRate;
        Debug.Log("�uanki alt�n de�eri : " + currentGold);
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
            Debug.LogWarning("Yeterli alt�n yok!");
            return false;
        }
    }
}

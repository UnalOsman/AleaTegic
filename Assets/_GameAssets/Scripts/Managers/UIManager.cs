using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GoldManager goldManager;

    [SerializeField] public TextMeshProUGUI goldCostText;
    private void GoldCostText()
    {
        goldCostText.text = "ALTIN : " + goldManager.currentGold.ToString();
    }

    private void Update()
    {
        GoldCostText();
    }
}

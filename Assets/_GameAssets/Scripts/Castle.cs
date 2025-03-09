using UnityEngine;

public class Castle : MonoBehaviour
{
    public int maxHealth = 1000;
    private float currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int  damage , UnitCombat playerCombat, float attackSpeed=1)
    {
        if(playerCombat.attackCoolDown <= 0f)
        {
            currentHealth -= damage;
            playerCombat.attackCoolDown = Mathf.Max(0.1f, 1f / attackSpeed);
            Debug.Log("kaleye sald�r� ger�ekle�ti. AttackCoolDown : " + playerCombat.attackCoolDown);
        }
        

        Debug.Log("Kale hasar ald�,kalenin �uanki can� : " +  currentHealth);

        if (currentHealth <= 0)
        {
            DestroyCastle();
        }
    }

    void DestroyCastle()
    {
        Debug.Log("Kale yok edildi.");
        Destroy(gameObject);
    }


}

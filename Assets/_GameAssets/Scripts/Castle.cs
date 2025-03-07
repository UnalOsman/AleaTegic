using UnityEngine;

public class Castle : MonoBehaviour
{
    public int maxHealth = 1000;
    private float currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int  damage , Unit player, float attackSpeed=1)
    {
        if(player.attackCoolDown <= 0f)
        {
            currentHealth -= damage;
            player.attackCoolDown = Mathf.Max(0.1f, 1f / attackSpeed);
            Debug.Log("kaleye sald�r� ger�ekle�ti. AttackCoolDown : " + player.attackCoolDown);
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

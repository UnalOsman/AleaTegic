using UnityEngine;

public class Castle : MonoBehaviour
{
    public int maxHealth = 1000;
    private float currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int  damage,float attackSpeed=1)
    {
        currentHealth -= damage * attackSpeed;

        Debug.Log("Kale hasar aldý,kalenin þuanki caný : " +  currentHealth);

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

using UnityEngine;

public class Castle : MonoBehaviour
{
    public int maxHealth = 1000;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int  damage)
    {
        currentHealth -= damage;

        Debug.Log("Kale hasar aldý,kalenin þuanki caný : " +  currentHealth);

        if (currentHealth <= 0)
        {
            DestroyCastle();
        }
    }

    void DestroyCastle()
    {
        Debug.Log("Kale yok edildi.");
    }


}

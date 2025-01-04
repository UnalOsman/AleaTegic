using UnityEngine;

public class Unit : MonoBehaviour
{
    public int attackPower;
    public int health;
    public int maxHealth;
    public int minHealth;
    public int GoldCost;
    public int featureValue;
    public float moveSpeed;
    public float attackSpeed;

    private Transform targetCastle;
    private Castle enemyCastle;

    public void SetTarget(Transform target)
    {
        targetCastle = target;
        enemyCastle=target.GetComponent<Castle>();
    }

    private void Update()
    {
        if (targetCastle != null)
        {
            float stopDistance = 25f;

            Vector3 targetPosition = new Vector3(targetCastle.position.x - stopDistance, transform.position.y, targetCastle.position.z);
            

            float distanceToTarget=Vector3.Distance(transform.position, targetPosition);

            if(distanceToTarget > 0.1f)
            {
                Vector3 direction = (targetPosition - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else
            {
                AttackCastle(attackPower,attackSpeed);
            }
        }
    }

    private void AttackCastle(int attackPower,float attackSpeed)
    {

        if(enemyCastle!=null)
        {
            enemyCastle.TakeDamage(attackPower,attackSpeed);
        }
    }
}

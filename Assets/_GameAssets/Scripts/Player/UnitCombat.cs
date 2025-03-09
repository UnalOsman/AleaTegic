using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UnitCombat : MonoBehaviour
{
    public int attackPower;
    public float attackSpeed;
    public float attackRange;
    public float attackCoolDown = 0f;

    private Unit unit;
    private Castle enemyCastle;

    private void Start()
    {
        unit = GetComponent<Unit>();
    }

    private void Update()
    {
        attackCoolDown -= Time.deltaTime;
    }
    
    public void AttackEnemy()
    {
        if(unit.currentTarget != null && attackCoolDown <= 0f)
        {
            float distanceToTarget = Vector3.Distance(transform.position, unit.currentTarget.transform.position);

            if(distanceToTarget <= attackRange)
            {
                unit.currentTarget.TakeDamage(attackPower);
                attackCoolDown = 1f / attackSpeed;
            }
        }
    }

    public void SetTarget(Castle targetCastle)
    {
        if (targetCastle == null)
        {
            Debug.LogError(gameObject.name + " i�in SetTarget() �a��r�ld� ancak Target NULL!!");
            return;
        }

        enemyCastle = targetCastle.GetComponent<Castle>();

        if (enemyCastle == null)
        {
            Debug.LogError(targetCastle.gameObject.name + " objesinde 'Castle' bile�eni eksik!");
        }
    }

    public void AttackCastle()
    {

        if (enemyCastle != null && attackCoolDown <= 0f)
        {
            enemyCastle.TakeDamage(attackPower,this,attackSpeed);
            attackCoolDown = 1f / attackSpeed;
            Debug.Log(gameObject.name + " kaleye sald�r�yor.");
        }
    }
}

using UnityEngine;

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

    public void SetTargetCastle(Transform target)
    {
        if(target == null)
        {
            Debug.LogError(gameObject.name + " için SetTarget() çaðrýldý ancak targetCastle NULL!");
            return;
        }
        else
        {
            enemyCastle = target.GetComponent<Castle>();
        }
        
    }
    /*
    public void SetTarget(Castle targetCastle)
    {
        if (targetCastle == null)
        {
            Debug.LogError(gameObject.name + " için SetTarget() çaðrýldý ancak targetCastle NULL!");
            return;
        }

        enemyCastle = targetCastle;
        Debug.Log(gameObject.name + " için enemyCastle baþarýyla ayarlandý: " + enemyCastle.gameObject.name);
    }
    */
    private void Update()
    {
        attackCoolDown -= Time.deltaTime;
    }

    public void AttackEnemy()
    {
        if (unit.currentTarget != null && attackCoolDown <= 0f)
        {
            float distanceToTarget = Vector3.Distance(transform.position, unit.currentTarget.transform.position);

            if (distanceToTarget <= attackRange)
            {
                unit.currentTarget.TakeDamage(attackPower);
                attackCoolDown = 1f / attackSpeed;
            }
        }
    }
    public void AttackCastle()
    {
        if (enemyCastle == null)
        {
            Debug.LogError(gameObject.name + " kaleye saldýrmaya çalýþýyor ancak enemyCastle NULL! SetTarget() düzgün çaðrýlmýþ mý kontrol et.");
            return;
        }
        else
        {
            if (attackCoolDown <= 0f)
            {
                enemyCastle.TakeDamage(attackPower, this, attackSpeed);
                attackCoolDown = 1f / attackSpeed;
                Debug.Log(gameObject.name + " kaleye saldýrýyor!");
            }
        }

        
    }
}


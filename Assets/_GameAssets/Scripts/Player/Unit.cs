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
    public float attackRange;
    public Unit currentTarget;

    private float attackCoolDown = 0f;

    private Transform targetCastle;
    private Castle enemyCastle;
    private IState currentState;

    private void Start()
    {
        currentState=new WalkingState();
        currentState.EnterState(this);
    }

    private void Update()
    {
        attackCoolDown -= Time.deltaTime;
        currentState?.UpdateState(this);
    }

    public void ChangeState(IState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    public void SetTarget(Transform target)
    {
        targetCastle = target;
        enemyCastle = target.GetComponent<Castle>();
    }

    public void UnitMovement()
    {
        if(currentTarget == null)
        {
            if (targetCastle != null)
            {
                float stopDistance = 25f;

                Vector3 targetPosition = new Vector3(targetCastle.position.x - stopDistance, transform.position.y, targetCastle.position.z);


                float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

                if (distanceToTarget > 0.1f)
                {
                    Vector3 direction = (targetPosition - transform.position).normalized;
                    transform.position += direction * moveSpeed * Time.deltaTime;
                }
                else
                {
                    ChangeState(new AttackState());
                }
            }
        }
        
    }

    public void AttackCastle(int attackPower,float attackSpeed)
    {

        if(enemyCastle!=null)
        {
            enemyCastle.TakeDamage(attackPower,attackSpeed);
            ChangeState(new DieState());
        }
    }

    public void AttackEnemy()
    {
        if(currentTarget!=null && attackCoolDown <= 0f)
        {
            float distanceToTarget=Vector3.Distance(transform.position,currentTarget.transform.position);

            if(distanceToTarget <= attackRange)
            {
                currentTarget.TakeDamage(attackPower);
                attackCoolDown = 1f / attackSpeed;
                Debug.Log(gameObject.name + " düþmana saldýrýyor -> " + currentTarget.gameObject.name);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " hasar aldý." + damage + " Kalan can : " + health);

        if(health <= 0f)
        {
            ChangeState(new DieState());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Unit enemyUnit = other.GetComponent<Unit>();

        if(enemyUnit != null && enemyUnit != this)
        {
            currentTarget = enemyUnit;
            ChangeState(new AttackState());
        }
    }
}

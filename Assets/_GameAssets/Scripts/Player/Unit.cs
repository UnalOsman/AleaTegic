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

    public float attackCoolDown = 0f;

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
        Debug.Log(gameObject.name + " attackCoolDown : " + attackCoolDown);
        FindClosestEnemy();
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
                    AttackCastle(attackPower,attackSpeed);
                }
            }
        }
        
    }

    public void AttackCastle(int attackPower,float attackSpeed)
    {

        if(enemyCastle!=null)
        {
            enemyCastle.TakeDamage(attackPower,attackSpeed);
        }
    }

    public void AttackEnemy()
    {
        Debug.Log("AttackEnemy fonksiyonuna giriþ yapýldý.");
        if(currentTarget!=null)
        {
            float distanceToTarget=Vector3.Distance(transform.position,currentTarget.transform.position);
            Debug.Log("Ýlk if içine girildi. DistanceToTarget deðeri : " + distanceToTarget);

            if(distanceToTarget <= attackRange)
            {
                currentTarget.TakeDamage(attackPower);
                Debug.Log(gameObject.name + " düþmana saldýrýyor -> " + currentTarget.gameObject.name);
            }
            else
            {
                Debug.Log("Düþman çok uzakta(" + distanceToTarget + "m)");
            }
        }
        else
        {
            Debug.Log("Saldýrý iptal edildi çünkü hedef yok.");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " hasar aldý : " + damage + " Kalan can : " + health);

        if(health <= 0f)
        {
            ChangeState(new DieState());
        }
    }

    private void FindClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        Unit closestEnemy = null;

        Unit[] allUnits = FindObjectsOfType<Unit>();

        foreach(Unit unit in allUnits)
        {
            if(unit !=this && unit.gameObject.tag != this.gameObject.tag)
            {
                float distance= Vector3.Distance(transform.position,unit.transform.position);
                if(distance < closestDistance && distance <= attackRange)
                {
                    closestDistance = distance;
                    closestEnemy = unit;
                }
            }
        }

        currentTarget = closestEnemy;

        if( currentTarget != null )
        {
            ChangeState(new AttackState());
        }
        else
        {
            ChangeState(new WalkingState());
        }
    }
}

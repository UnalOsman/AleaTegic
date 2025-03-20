using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public float moveSpeed;

    private Transform targetCastle;
    private Unit unit;
    private UnitCombat combat;
    private void Awake()
    {
        unit = GetComponent<Unit>();
        combat = GetComponent<UnitCombat>();
    }


    public void SetTarget(Transform target)
    {
        if (target == null)
        {
            Debug.LogError(gameObject.name + " i�in SetTarget() �a�r�ld� ancak target NULL!");
            return;
        }

        targetCastle = target;
        //Castle targetCastleComponent = target.GetComponent<Castle>();

        if (target != null)
        {
            combat?.SetTargetCastle(target);
            Debug.Log(gameObject.name + " i�in Castle bulundu ve sald�r� hedefi ayarland�!" + target.gameObject.name);
        }
        else
        {
            Debug.LogError(target.gameObject.name + " objesinde 'Castle' bile�eni bulunamad�!");
        }
    }

    public void MoveTowardsTarget()
    {
        if (unit.currentTarget == null)
        {
            if (targetCastle != null)
            {
                float stopDistance = 10f;

                if (this.gameObject.CompareTag("Player"))
                {
                    stopDistance = 10f;
                }
                else if (this.gameObject.CompareTag("Enemy"))
                {
                    stopDistance = -10f;
                }

                Vector3 targetPosition = new Vector3(targetCastle.position.x - stopDistance, transform.position.y, targetCastle.position.z);

                float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

                if (distanceToTarget > 0.1f)
                {
                    Vector3 direction = (targetPosition - transform.position).normalized;
                    transform.position += direction * moveSpeed * Time.deltaTime;
                }
                else
                {
                    combat.AttackCastle();
                }
            }

        }
    }
}


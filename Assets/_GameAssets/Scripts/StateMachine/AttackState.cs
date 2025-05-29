using UnityEngine;

public class AttackState : IState
{
    public void EnterState(Unit player)
    {
        Debug.Log(player.gameObject.name + " sald�r� durumuna ge�ti!");

        var anim = player.GetComponent<UnitAnimation>();
        if (anim != null) { anim.PlayAttack(); }
    }

    public void UpdateState(Unit player)
    {
        var combat = player.GetComponent<UnitCombat>();
        Castle castle = combat.GetEnemyCastle();

        // E�er hedef varsa ve ya��yorsa ona sald�r
        if (player.currentTarget != null && player.currentTarget.health > 0)
        {
            if (combat.attackCoolDown <= 0f)
            {
                combat.AttackEnemy();
                combat.attackCoolDown = Mathf.Max(0.1f, 1f / combat.attackSpeed);
            }
        }
        // E�er hedef yok ama kaleye yak�nsa ? kaleye sald�r
        else if (castle != null)
        {
            float distanceToCastle = Vector3.Distance(player.transform.position, castle.transform.position);

            if (distanceToCastle -10f <= combat.attackRange)
            {
                if (combat.attackCoolDown <= 0f)
                {
                    combat.AttackCastle();
                    combat.attackCoolDown = Mathf.Max(0.1f, 1f / combat.attackSpeed);
                }
            }
            else
            {
                player.ChangeState(new WalkingState());
                Debug.Log(player.gameObject.name + " kaleye h�l� uzak, y�r�meye ge�iyor.");
            }
        }

    }
    public void ExitState(Unit player)
    {
        Debug.Log(player.gameObject.name + " sald�r� durumundan ��kt�!");
    }
}

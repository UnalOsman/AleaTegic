using UnityEngine;

public class AttackState : IState
{
    public void EnterState(Unit player)
    {
        Debug.Log(player.gameObject.name + " saldýrý durumuna geçti!");

        var anim = player.GetComponent<UnitAnimation>();
        if (anim != null) { anim.PlayAttack(); }
    }

    public void UpdateState(Unit player)
    {
        var combat = player.GetComponent<UnitCombat>();
        Castle castle = combat.GetEnemyCastle();

        // Eðer hedef varsa ve yaþýyorsa ona saldýr
        if (player.currentTarget != null && player.currentTarget.health > 0)
        {
            if (combat.attackCoolDown <= 0f)
            {
                combat.AttackEnemy();
                combat.attackCoolDown = Mathf.Max(0.1f, 1f / combat.attackSpeed);
            }
        }
        // Eðer hedef yok ama kaleye yakýnsa ? kaleye saldýr
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
                Debug.Log(player.gameObject.name + " kaleye hâlâ uzak, yürümeye geçiyor.");
            }
        }

    }
    public void ExitState(Unit player)
    {
        Debug.Log(player.gameObject.name + " saldýrý durumundan çýktý!");
    }
}

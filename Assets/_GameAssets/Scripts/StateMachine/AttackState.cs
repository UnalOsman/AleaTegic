using UnityEngine;

public class AttackState : IState
{
    public void EnterState(Unit player)
    {
        Debug.Log(player.gameObject.name + " sald�r� durumuna ge�ti!");
    }

    public void UpdateState(Unit player)
    {
        UnitCombat playerCombat = player.GetComponent<UnitCombat>();

        if (player.currentTarget != null && player.currentTarget.health > 0)
        {
            Debug.Log(player.gameObject.name + " sald�r� yapmaya devam ediyor.");
            if(playerCombat.attackCoolDown <= 0f)
            {
                playerCombat.AttackEnemy();
                playerCombat.attackCoolDown = Mathf.Max(0.1f , 1f / playerCombat.attackSpeed);
                Debug.Log(player.gameObject.name + " tekrar sald�rd�.");
            }
        }
        else
        {
            //currentTarget null oldu�unda, asker kalenin menzilinde olmamas�na ra�men kaleye hasar veriyor.
            player.ChangeState(new WalkingState());
            Debug.Log(player.gameObject.name + " d��man �ld�, y�r�meye devam ediyor...");
        }
    }
    public void ExitState(Unit player)
    {
        Debug.Log(player.gameObject.name + " sald�r� durumundan ��kt�!");
    }
}

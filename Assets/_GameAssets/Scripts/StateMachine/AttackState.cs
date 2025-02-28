using UnityEngine;

public class AttackState : IState
{
    
    public void EnterState(Unit player)
    {
        Debug.Log(player.gameObject.name + " sald�r� durumuna ge�ti!");
    }


    public void UpdateState(Unit player)
    {
        if(player.currentTarget != null)
        {
            player.AttackEnemy();
        }
        else
        {
            player.AttackCastle(player.attackPower,player.attackSpeed);
        }
    }

    public void ExitState(Unit player)
    {
        Debug.Log(player.gameObject.name + " sald�r� durumundan ��kt�!");
    }

}

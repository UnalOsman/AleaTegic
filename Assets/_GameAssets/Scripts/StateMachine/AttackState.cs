using UnityEngine;

public class AttackState : IState
{
    
    public void EnterState(Unit player)
    {
        Debug.Log(player.gameObject.name + " saldýrý durumuna geçti!");
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
        Debug.Log(player.gameObject.name + " saldýrý durumundan çýktý!");
    }

}

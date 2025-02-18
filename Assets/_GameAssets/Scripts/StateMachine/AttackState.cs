using UnityEngine;

public class AttackState : IState
{
    
    public void EnterState(Unit player)
    {
        
    }

    public void ExitState(Unit player)
    {
        
    }

    public void UpdateState(Unit player)
    {
        player.AttackCastle(player.attackPower, player.attackSpeed);
    }

}

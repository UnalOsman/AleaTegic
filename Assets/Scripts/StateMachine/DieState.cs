using UnityEngine;

public class DieState : IState
{
    public void EnterState(Unit player)
    {
        Object.Destroy(player.gameObject);
    }

    public void ExitState(Unit player)
    {
        
    }

    public void UpdateState(Unit player)
    {
        //player.UnitMovement();
    }
}

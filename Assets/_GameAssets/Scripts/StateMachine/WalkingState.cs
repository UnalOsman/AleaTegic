using UnityEngine;

public class WalkingState : IState
{
    public void EnterState(Unit player)
    {
    }

    public void ExitState(Unit player)
    {
    }

    public void UpdateState(Unit player)
    {
        UnitMovement playerMovement = player.GetComponent<UnitMovement>();
        playerMovement.MoveTowardsTarget();
    }
}

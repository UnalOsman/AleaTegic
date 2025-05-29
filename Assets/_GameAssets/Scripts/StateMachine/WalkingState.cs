using UnityEngine;

public class WalkingState : IState
{
    public void EnterState(Unit player)
    {
        Debug.Log(player.gameObject.name + " tekrar yürümeye baþladý.");

        var anim = player.GetComponent<UnitAnimation>();
        if (anim != null) { anim.PlayWalk(); }
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

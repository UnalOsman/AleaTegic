using UnityEngine;

public class DieState : IState
{
    public void EnterState(Unit player)
    {
        Debug.Log(player.gameObject.name + " öldü.");

        var anim = player.GetComponent<UnitAnimation>();
        if (anim != null) { anim.PlayDie(); }

        Collider col = player.GetComponent<Collider>();
        if (col != null) { col.enabled = false; }
            

        Object.Destroy(player.gameObject,1f);
    }

    public void ExitState(Unit player)
    {
    }

    public void UpdateState(Unit player)
    {
        //player.UnitMovement();
    }
}

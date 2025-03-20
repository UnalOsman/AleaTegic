using UnityEngine;

public class AttackState : IState
{
    public void EnterState(Unit player)
    {
        Debug.Log(player.gameObject.name + " saldýrý durumuna geçti!");
    }

    public void UpdateState(Unit player)
    {
        UnitCombat playerCombat = player.GetComponent<UnitCombat>();

        if (player.currentTarget != null && player.currentTarget.health > 0)
        {
            Debug.Log(player.gameObject.name + " saldýrý yapmaya devam ediyor.");
            if(playerCombat.attackCoolDown <= 0f)
            {
                playerCombat.AttackEnemy();
                playerCombat.attackCoolDown = Mathf.Max(0.1f , 1f / playerCombat.attackSpeed);
                Debug.Log(player.gameObject.name + " tekrar saldýrdý.");
            }
        }
        else
        {
            //currentTarget null olduðunda, asker kalenin menzilinde olmamasýna raðmen kaleye hasar veriyor.
            player.ChangeState(new WalkingState());
            Debug.Log(player.gameObject.name + " düþman öldü, yürümeye devam ediyor...");
        }
    }
    public void ExitState(Unit player)
    {
        Debug.Log(player.gameObject.name + " saldýrý durumundan çýktý!");
    }
}

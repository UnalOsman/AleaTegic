using UnityEngine;

public class AttackState : IState
{
    
    public void EnterState(Unit player)
    {
        Debug.Log(player.gameObject.name + " saldýrý durumuna geçti!");
    }


    public void UpdateState(Unit player)
    {
        if(player.currentTarget != null && player.currentTarget.health > 0)
        {
            Debug.Log(player.gameObject.name + " saldýrý yapmaya devam ediyor.");
            if(player.attackCoolDown <= 0f)
            {
                player.AttackEnemy();
                player.attackCoolDown = Mathf.Max(0.1f , 1f / player.attackSpeed);
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

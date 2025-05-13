using System;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int health;
    public int minHealth;
    public int maxHealth;
    public int goldCost;
    public int featureValue;

    public Unit currentTarget;
    private IState currentState;
    private UnitMovement movement;
    private UnitCombat combat;
    

    private void Start()
    {
        UnitManager.Instance.RegisterUnit(this);
        movement = GetComponent<UnitMovement>();
        combat = GetComponent<UnitCombat>();

        currentState=new WalkingState();
        currentState.EnterState(this);
    }

    private void Update()
    {
        combat.attackCoolDown -= Time.deltaTime;
        FindClosestEnemy();
        currentState?.UpdateState(this);
    }

    private void OnDestroy()
    {
        UnitManager.Instance?.UnregisterUnit(this);
    }

    public void ChangeState(IState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " hasar aldý : " + damage + " Kalan can : " + health);

        if(health <= 0f)
        {
            ChangeState(new DieState());
        }
    }

    private void FindClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        Unit closestEnemy = null;

        List<Unit> allUnits = UnitManager.Instance.GetAllUnits();

        foreach(Unit unit in allUnits )
        {
            if(unit !=this && unit.gameObject.tag != this.gameObject.tag)
            {
                float distance= Vector3.Distance(transform.position,unit.transform.position);

                if (distance < 3.5f)
                    continue;

                if(distance < closestDistance && distance <= combat.attackRange)
                {
                    closestDistance = distance;
                    closestEnemy = unit;
                }
            }
        }

        currentTarget = closestEnemy;

        if( currentTarget != null )
        {
            ChangeState(new AttackState());
        }
        else
        {
            ChangeState(new WalkingState());
        }
    }

    /*public static implicit operator Transform(Unit v)
    {
        throw new NotImplementedException();
    }*/
}

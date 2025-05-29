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

    public Transform currentTargetCastle;
    public Unit currentTarget;
    private IState currentState;
    private UnitMovement movement;
    private UnitCombat combat;

    private void Awake()
    {
        movement = GetComponent<UnitMovement>();
        combat = GetComponent<UnitCombat>();
    }

    private void Start()
    {
        UnitManager.Instance.RegisterUnit(this);
        

        currentState=new WalkingState();
        currentState.EnterState(this);
    }

    private void Update()
    {
        combat.attackCoolDown -= Time.deltaTime * 0.2f;
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

        var anim = gameObject.GetComponent<UnitAnimation>();
        if (anim != null) { anim.PlayHit(); }

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

        if (closestEnemy != null)
        {
            currentTarget = closestEnemy;
            ChangeState(new AttackState());
        }
        else
        {
            // Kale menzildeyse ona saldýr
            if (currentTargetCastle != null)
            {
                float distanceToCastle = Vector3.Distance(transform.position, currentTargetCastle.position);
                if (distanceToCastle - 10f <= combat.attackRange)
                {
                    ChangeState(new AttackState());
                    return;
                }
            }

            ChangeState(new WalkingState());
        }
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_HurtState : HurtState
{
     
     private Enemy5 enemy;
    protected bool done;
    protected float counter;
    public E5_HurtState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Enemy5 enemy) : base(etity, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        
    }

    public override void Enter()
    {
        base.Enter();
        counter = 0f;
    }

    public override void Exit()
    {
        base.Exit();
        counter = 0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        counter++;
  
        if (counter > 20f)
        {

            //Debug.Log("VALUE IS");
              Debug.Log(counter);
              stateMachine.ChangeState(enemy.moveState );
           
        }
       
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
  
}

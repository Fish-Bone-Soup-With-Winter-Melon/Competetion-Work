using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected Animator animator;

    protected PlayerStateMachine stateMachine;

    protected Rigidbody2D rigidbody2D;
    protected PlayerController playerController;
    public PlayerStateMachine playerStateMachine1;
    public ActionController actionController;
    protected PlayerValues playerValues;
    public void Initialize(Animator animator, PlayerStateMachine stateMachine, Rigidbody2D rigidbody2D, PlayerController playerController,ActionController actionController,PlayerValues playerValues)
    {
        // Debug.Log(playerController);
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.rigidbody2D = rigidbody2D;
        this.playerController = playerController;
        this.actionController = actionController;
        this.playerValues = playerValues;
    }
    public void Initialize(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine1 = playerStateMachine;
    }
    public void SetState(string stateName)
    {
        playerValues.currentState = stateName;
        Debug.Log(stateName);
    }
    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate()
    {

    }
}

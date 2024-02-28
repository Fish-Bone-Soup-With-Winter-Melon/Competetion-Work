using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected Animator animator;
    
    protected PlayerStateMachine stateMachine;
    
    protected Rigidbody2D rigidbody2D;
    protected PlayerController playerController;
    public void Initialize(Animator animator, PlayerStateMachine stateMachine,Rigidbody2D rigidbody2D,PlayerController playerController)
    {
        // Debug.Log(playerController);
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.rigidbody2D = rigidbody2D;
        this.playerController = playerController;
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

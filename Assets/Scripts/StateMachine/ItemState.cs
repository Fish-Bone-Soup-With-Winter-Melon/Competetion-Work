using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemState : ScriptableObject, IState
{
    protected Animator animator;
    
    protected ItemStateMachine stateMachine;
    
    protected Rigidbody2D rigidbody2D;
    protected GameObject gameObject;
    // protected PlayerController playerController;
    public void Initialize(Animator animator, ItemStateMachine stateMachine,Rigidbody2D rigidbody2D,GameObject gameObject)
    {
        // Debug.Log(playerController);
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.rigidbody2D = rigidbody2D;
        this.gameObject = gameObject;
        // this.playerController = playerController;
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

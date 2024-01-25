using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    //碰撞检测不知道该写在哪才能生效
    // public bool collisionFlag = false;
    IState currentState;
    public PlayerStateIdle playerStateIdle;
    void Start()
    {
        currentState = playerStateIdle;
    }
    void Update()
    {
        currentState.LogicUpdate();
    }
    void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }
    protected void SwitchOn(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }
    public void SwitchState(IState newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }
    // void OnCollisionEnter()
    // {
    //     collisionFlag = true;
    // }
    // void OnCollisionExit()
    // {
    //     collisionFlag = false;
    // }
}

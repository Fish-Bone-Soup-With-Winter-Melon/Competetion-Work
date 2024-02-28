using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    //碰撞检测不知道该写在哪才能生效
    // public bool collisionFlag = false;
    public IState currentState;
    public Dictionary<System.Type,IState> stateTable;
    protected virtual void Start()
    {

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
    public void SwitchState(System.Type stateType)
    {
        SwitchState(stateTable[stateType]);
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

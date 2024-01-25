using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public PlayerStateIdle stateIdle;
    public PlayerStateRun stateRun;
    public PlayerStateJump stateJump;
    Animator animator;
    public new GameObject gameObject;
    public new Rigidbody2D rigidbody;
    
    
    //在这里设置角色初始数据
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        stateIdle.Initialize(animator,this);
        stateRun.Initialize(animator,this);
        stateJump.Initialize(animator,this);
    }
}

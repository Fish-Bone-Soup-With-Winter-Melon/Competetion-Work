using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public PlayerStateIdle stateIdle;
    public PlayerStateRun stateRun;
    public PlayerStateJump stateJump;
    public PlayerStateDash stateDash;
    Animator animator;
    public GameObject plyaerObject;
    public Rigidbody2D playerRigidbody;

    protected override void Start()
    {
        currentState = stateIdle;
    }
    //在这里设置角色初始数据
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        stateIdle.Initialize(animator,this,playerRigidbody);
        stateRun.Initialize(animator,this,playerRigidbody);
        stateJump.Initialize(animator,this,playerRigidbody);
        stateDash.Initialize(animator,this,playerRigidbody);
    }
}

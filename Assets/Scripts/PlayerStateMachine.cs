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
    public PlayerStateInAir stateInAir;
    Animator animator;
    public GameObject plyaerObject;
    public Rigidbody2D playerRigidbody;
    public PlayerController playerController;

    protected override void Start()
    {
        currentState = stateIdle;
    }
    //在这里设置角色初始数据
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
        stateIdle.Initialize(animator,this,playerRigidbody,playerController);
        stateRun.Initialize(animator,this,playerRigidbody,playerController);
        stateJump.Initialize(animator,this,playerRigidbody,playerController);
        stateDash.Initialize(animator,this,playerRigidbody,playerController);
        stateInAir.Initialize(animator,this,playerRigidbody,playerController);
    }
}

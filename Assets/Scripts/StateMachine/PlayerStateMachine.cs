using System.Collections;
using System.Collections.Generic;
using System.Data;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    //public PlayerStateIdle stateIdle;
    //public PlayerStateRun stateRun;
    //public PlayerStateJump stateJump;
    //public PlayerStateDash stateDash;
    //public PlayerStateInAir stateInAir;
    [SerializeField] PlayerState[] states;
    public PlayerValues playerValues;
    Animator animator;
    public GameObject plyaerObject;
    public Rigidbody2D playerRigidbody;
    public PlayerController playerController;
    public Vector2 speedBoost;
    public PlayerStateRun playerStateRun;
    public PlayerStateInAir playerStateInAir;
    public ActionController actionController;
    //在这里设置角色初始数据
    void Awake()
    {
        stateTable = new Dictionary<System.Type, IState>(states.Length);
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
        actionController = GetComponent<ActionController>();
        foreach (PlayerState state in states)
        {
            state.Initialize(animator, this, playerRigidbody, playerController,actionController);
            stateTable.Add(state.GetType(), state);
        }
        playerStateRun = (PlayerStateRun)stateTable[typeof(PlayerStateRun)];
        playerStateRun.Initialize(this);
        playerStateInAir = (PlayerStateInAir)stateTable[typeof(PlayerStateInAir)];
        playerStateInAir.Initialize(this);
    }
    protected override void Start()
    {
        SwitchOn(stateTable[typeof(PlayerStateInAir)]);
    }
}

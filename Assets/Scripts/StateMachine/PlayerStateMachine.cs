using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    // public PlayerStateIdle stateIdle;
    // public PlayerStateRun stateRun;
    // public PlayerStateJump stateJump;
    // public PlayerStateDash stateDash;
    // public PlayerStateInAir stateInAir;
    [SerializeField] PlayerState[] states;
    public PlayerValues playerValues;
    Animator animator;
    public GameObject plyaerObject;
    public Rigidbody2D playerRigidbody;
    public PlayerController playerController;

    
    //在这里设置角色初始数据
    void Awake()
    {
        stateTable = new Dictionary<System.Type, IState>(states.Length);
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
        foreach (PlayerState state in states)
        {
            state.Initialize(animator,this,playerRigidbody,playerController);
            stateTable.Add(state.GetType(),state);
        }
    }
    protected override void Start()
    {
        SwitchOn(stateTable[typeof(PlayerStateInAir)]);
    }
}

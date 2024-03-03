using System.Collections;
using System.Collections.Generic;
using System.Data;
using JetBrains.Annotations;
using Unity.VisualScripting;
// using UnityEditorInternal;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
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
    public PlayerStateAfterDash playerStateAfterDash;
    public CollisionManager collisionManager;
    public PlayerTerrain playerTerrain;
    //在这里设置角色初始数据
    void Awake()
    {
        playerTerrain = GetComponent<PlayerTerrain>();
        playerValues = new PlayerValues();
        stateTable = new Dictionary<System.Type, IState>(states.Length);
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
        actionController = GetComponent<ActionController>();
        collisionManager = GetComponent<CollisionManager>();
        playerTerrain.playerValues = playerValues;
        speedBoost = playerValues.boostVelocity;
        collisionManager.playerValues = playerValues;

        playerRigidbody.gravityScale = playerValues.gravityScale;
        foreach (PlayerState state in states)
        {
            state.Initialize(animator, this, playerRigidbody, playerController,actionController,playerValues);
            stateTable.Add(state.GetType(), state);
        }

        playerStateRun = (PlayerStateRun)stateTable[typeof(PlayerStateRun)];
        playerStateRun.Initialize(this);
        playerStateInAir = (PlayerStateInAir)stateTable[typeof(PlayerStateInAir)];
        playerStateInAir.Initialize(this);
        playerStateAfterDash = (PlayerStateAfterDash)stateTable[typeof(PlayerStateAfterDash)];
        playerStateAfterDash.Initialize(this);

        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    protected override void Start()
    {
        SwitchOn(stateTable[typeof(PlayerStateInAir)]);
    }
}

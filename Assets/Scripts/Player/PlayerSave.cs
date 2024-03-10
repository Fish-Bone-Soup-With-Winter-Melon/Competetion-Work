using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    public Rigidbody2D rigidbody2D_1;
    public PlayerStateMachine playerStateMachine;
    void Start()
    {
        rigidbody2D_1 = GetComponent<Rigidbody2D>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
    }

    void Update()
    {
        playerStateMachine.playerValues.curVelocity = rigidbody2D_1.velocity;
        playerStateMachine.playerValues.position = transform.position;
        playerStateMachine.playerValues.currentState = playerStateMachine.currentState.ToString();
        if (playerStateMachine.playerValues.currentState == typeof(PlayerStateDash).ToString())
        {
            playerStateMachine.playerValues.dashDirection = (int)playerStateMachine.playerStateDash.direction;
        }
    }
}

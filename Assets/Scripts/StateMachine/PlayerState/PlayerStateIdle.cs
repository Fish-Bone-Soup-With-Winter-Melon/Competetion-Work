using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerStateIdle : PlayerState
{
    public override void Enter()
    {
        // stateMachine.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        actionController.Stand();
        rigidbody2D.velocity = new Vector2(0,0);
        // Debug.Log("Idle");
    }
    
    public override void LogicUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            stateMachine.SwitchState(typeof(PlayerStateRun));
        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.SwitchState(typeof(PlayerStateRun));
        if (Input.GetKeyDown(KeyCode.D))
            stateMachine.SwitchState(typeof(PlayerStateRun));
        if (playerController.isGround == false)
        {
            stateMachine.SwitchState(typeof(PlayerStateInAir));
        }
    }
    public override void PhysicUpdate()
    {
        
    }
    public override void Exit()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Data;
// using UnityEditor.Experimental.GraphView;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/AfterDash", fileName = "PlayerState_AfterDash")]
public class PlayerStateAfterDash : PlayerState
{
    public float xSpeed;
    public override void Enter()
    {
        // Debug.Log("InAir");
        SetState("PlayerStateAfterDash");
        xSpeed = playerValues.initialVelocity.x;
    }
    
    public override void LogicUpdate()
    {
        // 暂时不这样检测，等待碰撞检测的完善
        // if(playerController.isMud || playerController.isGround || playerController.isIce)
        //     stateMachine.SwitchState(stateMachine.stateIdle);
        actionController.Jump();
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            // stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(-xSpeed,0);
            rigidbody2D.velocity = new Vector2(-xSpeed,rigidbody2D.velocity.y) - playerValues.boostVelocity - playerValues.terrainVelocity;            
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            // stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(xSpeed,0);
            rigidbody2D.velocity = new Vector2(xSpeed,rigidbody2D.velocity.y) + playerValues.boostVelocity + playerValues.terrainVelocity;
        }
        // if(Input.GetKeyUp(KeyCode.RightArrow))
        // {
        //     // stateMachine.GetComponent<Rigidbody2D>().velocity -= new Vector2(xSpeed,0);
        //     rigidbody2D.velocity = new Vector2(xSpeed,0);
        // }
        // else if(Input.GetKeyUp(KeyCode.LeftArrow))
        // {
        //     // stateMachine.GetComponent<Rigidbody2D>().velocity -= new Vector2(-xSpeed,0);
        //     rigidbody2D.velocity = new Vector2(-xSpeed,0);
        // }
        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
        }
        // Debug.Log(playerController.isGround);
        if(playerController.isGround == true)
            stateMachine.SwitchState(typeof(PlayerStateIdle));
        // if (Input.GetKeyDown(KeyCode.D))
        //     stateMachine.SwitchState(typeof(PlayerStateDash));
    }
    public override void PhysicUpdate()
    {
        
    }
    public override void Exit()
    {
        
    }
}

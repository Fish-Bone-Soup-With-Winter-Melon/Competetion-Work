using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/InAir", fileName = "PlayerState_InAir")]
public class PlayerStateInAir : PlayerState
{
    public float xSpeed = 5.0f;
    public float ySpeed = 5.0f;
    public override void Enter()
    {
        Debug.Log("InAir");
    }
    
    public override void LogicUpdate()
    {
        // 暂时不这样检测，等待碰撞检测的完善
        // if(playerController.isMud || playerController.isGround || playerController.isIce)
        //     stateMachine.SwitchState(stateMachine.stateIdle);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            // stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(-xSpeed,0);
            rigidbody2D.velocity = new Vector2(-xSpeed,rigidbody2D.velocity.y);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            // stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(xSpeed,0);
            rigidbody2D.velocity = new Vector2(xSpeed,rigidbody2D.velocity.y);
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
        if(playerController.isGround == true)//临时使用 y 轴速度检测来退出跳跃状态，这是有 bug（空中 y 轴速度容易为 0 ）的
            stateMachine.SwitchState(stateMachine.stateIdle);
        if (Input.GetKeyDown(KeyCode.D))
            stateMachine.SwitchState(stateMachine.stateDash);
    }
    public override void PhysicUpdate()
    {
        
    }
    public override void Exit()
    {
        
    }
}

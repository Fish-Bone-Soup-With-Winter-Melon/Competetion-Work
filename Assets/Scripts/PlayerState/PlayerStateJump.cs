using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Jump", fileName = "PlayerState_Jump")]
public class PlayerStateJump : PlayerState
{
    public float xSpeed = 5.0f;
    public float ySpeed = 5.0f;
    public Vector2 velocity;
    public override void Enter()
    {
        stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(0,ySpeed);
    }
    public override void LogicUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(-xSpeed,0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(xSpeed,0);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            stateMachine.GetComponent<Rigidbody2D>().velocity -= new Vector2(xSpeed,0);
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            stateMachine.GetComponent<Rigidbody2D>().velocity -= new Vector2(-xSpeed,0);
        }
        if(stateMachine.GetComponent<Rigidbody2D>().velocity.y == 0)//临时使用 y 轴速度检测来退出跳跃状态
            stateMachine.SwitchState(stateMachine.stateIdle);
    }
    public override void PhysicUpdate()
    {
        
    }
    public override void Exit()
    {
        
    }
}

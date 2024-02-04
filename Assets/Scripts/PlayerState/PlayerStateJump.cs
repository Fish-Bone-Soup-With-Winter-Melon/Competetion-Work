using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Xml.Xsl;
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
        // stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(0,ySpeed);
        rigidbody2D.velocity += new Vector2(0,ySpeed);
        stateMachine.SwitchState(stateMachine.stateInAir);
    }
    public override void LogicUpdate()
    {
        // if(Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     // stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(-xSpeed,0);
        //     rigidbody2D.velocity += new Vector2(-xSpeed,0);
        // }
        // else if(Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     // stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(xSpeed,0);
        //     rigidbody2D.velocity += new Vector2(xSpeed,0);
        // }
        // if(Input.GetKeyUp(KeyCode.RightArrow))
        // {
        //     // stateMachine.GetComponent<Rigidbody2D>().velocity -= new Vector2(xSpeed,0);
        //     rigidbody2D.velocity -= new Vector2(xSpeed,0);
        // }
        // else if(Input.GetKeyUp(KeyCode.LeftArrow))
        // {
        //     // stateMachine.GetComponent<Rigidbody2D>().velocity -= new Vector2(-xSpeed,0);
        //     rigidbody2D.velocity -= new Vector2(-xSpeed,0);
        // }
        // if(rigidbody2D.velocity.y == 0)//临时使用 y 轴速度检测来退出跳跃状态
        //     stateMachine.SwitchState(stateMachine.stateIdle);
        // if (Input.GetKeyDown(KeyCode.D))
        //     stateMachine.SwitchState(stateMachine.stateDash);
    }
    public override void PhysicUpdate()
    {
        
    }
    public override void Exit()
    {
        
    }
}

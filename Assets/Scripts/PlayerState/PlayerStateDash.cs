using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Dash", fileName = "PlayerState_Dash")]
public class PlayerStateDash : PlayerState
{
    private float timer;
    public float timeLimit =0.3f;
    public float dashSpeed = 15f;
    public override void Enter()
    {
        rigidbody2D.gravityScale = 0;//清除重力
        timer = 0;
        if(Input.GetKey(KeyCode.RightArrow))
            rigidbody2D.velocity = new Vector2(dashSpeed,0);
        else if(Input.GetKey(KeyCode.LeftArrow))
            rigidbody2D.velocity = new Vector2(-dashSpeed,0);
        else if(Input.GetKey(KeyCode.UpArrow))
            rigidbody2D.velocity = new Vector2(0,dashSpeed);
        else if(Input.GetKey(KeyCode.DownArrow))
            rigidbody2D.velocity = new Vector2(0,-dashSpeed);
        else
            rigidbody2D.velocity = new Vector2(dashSpeed,0);
    }
    
    public override void LogicUpdate()
    {
        timer += Time.deltaTime;
        //do something
        if(timer >= timeLimit)
            stateMachine.SwitchState(stateMachine.stateIdle);
    }
    public override void PhysicUpdate()
    {
        
    }
    public override void Exit()
    {
        rigidbody2D.gravityScale = 1;//调回重力
    }
}


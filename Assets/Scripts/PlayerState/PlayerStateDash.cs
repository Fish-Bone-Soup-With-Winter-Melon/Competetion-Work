using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Dash", fileName = "PlayerState_Dash")]
public class PlayerStateDash : PlayerState
{
    private float timer;
    public float dashTimeLimit =0.6f;
    public float inputTimeLimit = 0.3f;
    public float dashSpeed = 15f;
    private bool isDashed;
    private enum Direction
    {
        Right,Left,Up,Down,RightUp,RightDown,LeftUp,LeftDown,Default
    }
    private Direction direction = Direction.Default;
    public void Identify()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            // rigidbody2D.velocity = new Vector2(dashSpeed,0);
            direction = Direction.Right;
            isDashed = true;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            // rigidbody2D.velocity = new Vector2(-dashSpeed,0);
            direction = Direction.Left;
            isDashed = true;
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            // rigidbody2D.velocity = new Vector2(0,dashSpeed);
            direction = Direction.Up;
            isDashed = true;
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            // rigidbody2D.velocity = new Vector2(0,-dashSpeed);
            direction = Direction.Down;
            isDashed = true;
        }
        // else
        //     rigidbody2D.velocity = new Vector2(dashSpeed,0);
    }
    public void Dash()
    {
        if (direction == Direction.Right || direction == Direction.Default)
        {
            rigidbody2D.velocity = new Vector2(dashSpeed,0);
        }
        else if (direction == Direction.Left)
        {
            rigidbody2D.velocity = new Vector2(-dashSpeed,0);
        }
        else if (direction == Direction.Up)
        {
            rigidbody2D.velocity = new Vector2(0,dashSpeed);
        }
        else if (direction == Direction.Down)
        {
            rigidbody2D.velocity = new Vector2(0,-dashSpeed);
        }
    }
    public override void Enter()
    {
        rigidbody2D.gravityScale = 0;//清除重力
        timer = 0;
        rigidbody2D.velocity = new Vector2(0,0);
        isDashed = false;
        direction = Direction.Default;
    }
    
    public override void LogicUpdate()
    {
        timer += Time.deltaTime;
        if(isDashed == false && timer <= inputTimeLimit )
            Identify();
        // Debug.Log(isDashed);
        // Debug.Log(direction);
        Dash();
        if(timer >= dashTimeLimit)
            stateMachine.SwitchState(stateMachine.stateInAir);
    }
    public override void PhysicUpdate()
    {
        
    }
    public override void Exit()
    {
        rigidbody2D.gravityScale = 1;//调回重力
        rigidbody2D.velocity = new Vector2(0,0);
    }
}


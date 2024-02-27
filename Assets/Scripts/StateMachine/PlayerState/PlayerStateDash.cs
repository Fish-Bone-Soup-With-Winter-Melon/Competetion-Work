using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Dash", fileName = "PlayerState_Dash")]
public class PlayerStateDash : PlayerState
{
    private float timer;
    public float dashTimeLimit = 0.5f;
    public float inputTimeLimit = 0.05f;
    public float dashSpeed = 50f;
    private bool isDashed;
    private enum Direction
    {
        Right, Left, Up, Down, RightUp, RightDown, LeftUp, LeftDown, Default
    }
    private Direction direction = Direction.Default;
    public void Identify()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            // rigidbody2D.velocity = new Vector2(dashSpeed,0);
            direction = Direction.RightDown;
            // isDashed = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            // rigidbody2D.velocity = new Vector2(-dashSpeed,0);
            direction = Direction.RightUp;
            // isDashed = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            // rigidbody2D.velocity = new Vector2(0,dashSpeed);
            direction = Direction.LeftDown;
            // isDashed = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            // rigidbody2D.velocity = new Vector2(0,-dashSpeed);
            direction = Direction.LeftUp;
            // isDashed = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // rigidbody2D.velocity = new Vector2(dashSpeed,0);
            direction = Direction.Right;
            // isDashed = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // rigidbody2D.velocity = new Vector2(-dashSpeed,0);
            direction = Direction.Left;
            // isDashed = true;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            // rigidbody2D.velocity = new Vector2(0,dashSpeed);
            direction = Direction.Up;
            // isDashed = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // rigidbody2D.velocity = new Vector2(0,-dashSpeed);
            direction = Direction.Down;
            // isDashed = true;
        }
        
        // else
        //     rigidbody2D.velocity = new Vector2(dashSpeed,0);
    }
    public void Dash()
    {
        if (direction == Direction.LeftDown)
        {
            rigidbody2D.velocity = new Vector2(-(float)Math.Pow(dashSpeed*dashSpeed/2,0.5), -(float)Math.Pow(dashSpeed*dashSpeed/2,0.5));
        }
        else if (direction == Direction.RightDown)
        {
            rigidbody2D.velocity = new Vector2((float)Math.Pow(dashSpeed*dashSpeed/2,0.5), -(float)Math.Pow(dashSpeed*dashSpeed/2,0.5));
        }
        else if (direction == Direction.LeftUp)
        {
            rigidbody2D.velocity = new Vector2(-(float)Math.Pow(dashSpeed*dashSpeed/2,0.5), (float)Math.Pow(dashSpeed*dashSpeed/2,0.5));
        }
        else if (direction == Direction.RightUp)
        {
            rigidbody2D.velocity = new Vector2((float)Math.Pow(dashSpeed*dashSpeed/2,0.5), (float)Math.Pow(dashSpeed*dashSpeed/2,0.5));
        }
        else if (direction == Direction.Right || direction == Direction.Default)
        {
            rigidbody2D.velocity = new Vector2(dashSpeed, 0);
        }
        else if (direction == Direction.Left)
        {
            rigidbody2D.velocity = new Vector2(-dashSpeed, 0);
        }
        else if (direction == Direction.Up)
        {
            rigidbody2D.velocity = new Vector2(0, dashSpeed);
        }
        else if (direction == Direction.Down)
        {
            rigidbody2D.velocity = new Vector2(0, -dashSpeed);
        }
        
        isDashed = true;
    }
    public override void Enter()
    {
        rigidbody2D.gravityScale = 0;//清除重力
        timer = 0;
        rigidbody2D.velocity = new Vector2(0, 0);
        isDashed = false;
        direction = Direction.Default;
    }

    public override void LogicUpdate()
    {

    }
    public override void PhysicUpdate()
    {
        timer += Time.deltaTime;
        if (isDashed == false && timer >= inputTimeLimit)
        {
            Identify();
            Dash();
        }
        if ((direction == Direction.Left || direction == Direction.Right) && rigidbody2D.velocity.x == 0)
        {
            stateMachine.SwitchState(typeof(PlayerStateInAir));
        }
        else if ((direction == Direction.Up || direction == Direction.Down) && rigidbody2D.velocity.y == 0)
        {
            // stateMachine.SwitchState(stateMachine.stateInAir);
            stateMachine.SwitchState(typeof(PlayerStateInAir));
        }
        else if ((direction == Direction.LeftDown || direction == Direction.LeftUp || direction == Direction.RightUp || direction == Direction.RightDown) && (rigidbody2D.velocity.y == 0 || rigidbody2D.velocity.x == 0))
        {
            rigidbody2D.velocity = new Vector2(0,0);
            stateMachine.SwitchState(typeof(PlayerStateInAir));
        }
        if (timer >= dashTimeLimit)
            // stateMachine.SwitchState(stateMachine.stateInAir);
            stateMachine.SwitchState(typeof(PlayerStateInAir));
    }
    public override void Exit()
    {
        rigidbody2D.gravityScale = 1;//调回重力
        rigidbody2D.velocity = new Vector2(0, 0);
        // 也许可以加入冲刺后的惯性
    }
}


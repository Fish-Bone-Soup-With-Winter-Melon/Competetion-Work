using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Dash", fileName = "PlayerState_Dash")]
public class PlayerStateDash : PlayerState
{
    public float timer;
    public float dashTimeLimit = 0.6f;
    public float inputTimeLimit = 0.05f;
    public float dashSpeed;
    public bool isDashed;
    public float halfDashSpeed;
    public CircleCollider2D[] circleCollider2Ds;
    public LayerMask tilemapLayer;
    public bool isGround;
    public bool isFloor;
    public BoxCollider2D boxCollider2D;
    public void Initialize(CircleCollider2D[] circleCollider2Ds, BoxCollider2D boxCollider2D)
    {
        this.circleCollider2Ds = circleCollider2Ds;
        this.boxCollider2D = boxCollider2D;
    }
    public enum Direction
    {
        Right, Left, Up, Down, RightUp, RightDown, LeftUp, LeftDown, Default
    }
    public Direction direction = Direction.Default;
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
            rigidbody2D.velocity = new Vector2(-halfDashSpeed, -halfDashSpeed);
        }
        else if (direction == Direction.RightDown)
        {
            rigidbody2D.velocity = new Vector2(halfDashSpeed, -halfDashSpeed);
        }
        else if (direction == Direction.LeftUp)
        {
            rigidbody2D.velocity = new Vector2(-halfDashSpeed, halfDashSpeed);
        }
        else if (direction == Direction.RightUp)
        {
            rigidbody2D.velocity = new Vector2(halfDashSpeed, halfDashSpeed);
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
        foreach (CircleCollider2D circleCollider2D in circleCollider2Ds)
        {
            circleCollider2D.enabled = false;
        }
        boxCollider2D.size += new Vector2(0, 0.2f);
        isDashed = true;
    }
    public override void Enter()
    {
        SetState("PlayerStateDash");
        dashSpeed = 20f;
        halfDashSpeed = (float)Math.Pow(dashSpeed * dashSpeed / 2, 0.5);
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
            actionController.Dash();
        }
        if ((direction == Direction.Left || direction == Direction.Right) && rigidbody2D.velocity.x == 0)
        {
            stateMachine.SwitchState(typeof(PlayerStateAfterDash));
        }
        else if ((direction == Direction.Up || direction == Direction.Down) && rigidbody2D.velocity.y == 0)
        {
            // stateMachine.SwitchState(stateMachine.stateInAir);
            stateMachine.SwitchState(typeof(PlayerStateAfterDash));
        }
        else if ((direction == Direction.LeftDown || direction == Direction.LeftUp || direction == Direction.RightUp || direction == Direction.RightDown) && (rigidbody2D.velocity.y == 0 || rigidbody2D.velocity.x == 0))
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            stateMachine.SwitchState(typeof(PlayerStateAfterDash));
        }
        if (timer >= dashTimeLimit)
            // stateMachine.SwitchState(stateMachine.stateInAir);
            stateMachine.SwitchState(typeof(PlayerStateAfterDash));

    }
    public override void Exit()
    {
        rigidbody2D.gravityScale = playerValues.gravityScale;//调回重力
        Debug.Log(rigidbody2D.gravityScale);
        rigidbody2D.velocity = new Vector2(0, 0);
        foreach (CircleCollider2D circleCollider2D in circleCollider2Ds)
        {
            circleCollider2D.enabled = true;
        }
        if ((playerController.isGround||playerController.isIce||playerController.isMud) && playerController.rayLength < 0)
        {
            Debug.Log("Ground");
            rigidbody2D.position -= new Vector2(0, 1f);
        }

        boxCollider2D.size -= new Vector2(0, 0.2f);
        Debug.Log("Dash Exit");
        if (playerStateMachine1 == null)
        {
            Debug.Log("PlayerStateMachine1 is null");
        }
        else
        {
            Debug.Log("PlayerStateMachine1 is not null");
            if (playerStateMachine1.playerValuesHandler == null)
            {
                Debug.Log("PlayerValuesHandler is null");
            }
            else
            {
                Debug.Log("PlayerValuesHandler is not null");
            }
        }
        //stateMachine.playerValuesHandler.ValuesToJson();
        // 也许可以加入冲刺后的惯性
    }
    public RaycastHit2D CreateOffsetRaycast(Vector2 offset, Vector2 diraction, float length, LayerMask layer)
    {
        Vector2 playerPosition = rigidbody2D.position;
        RaycastHit2D hit = Physics2D.Raycast(playerPosition + offset, diraction, length, layer);
        //Debug.Log("Drawed");
        Color rayColor = hit ? Color.red : Color.green;
        Debug.DrawRay(playerPosition + offset, diraction * length, rayColor);
        return hit;
    }
}


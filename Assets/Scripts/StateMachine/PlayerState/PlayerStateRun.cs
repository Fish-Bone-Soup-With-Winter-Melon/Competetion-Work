using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerStateRun : PlayerState
{
    public float xSpeed;
    public override void Enter()
    {
        //放动画！
        // animator.Play("Run");
        xSpeed = playerValues.initialVelocity.x;
    }
    public override void PhysicUpdate()
    {
        //临时性的移动措施
        
    }
    public override void LogicUpdate()
    {
        actionController.Run();
        if(Input.GetKey(KeyCode.RightArrow))
            // stateMachine.GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed,0);
            rigidbody2D.velocity = new Vector2(xSpeed,0) + playerStateMachine1.speedBoost;
        else if(Input.GetKey(KeyCode.LeftArrow))
            // stateMachine.GetComponent<Rigidbody2D>().velocity = new Vector2(-xSpeed,0);
            rigidbody2D.velocity = new Vector2(-xSpeed,0) - playerStateMachine1.speedBoost;

        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            stateMachine.SwitchState(typeof(PlayerStateIdle));
            
        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.SwitchState(typeof(PlayerStateJump));
        if (Input.GetKeyDown(KeyCode.D))
            stateMachine.SwitchState(typeof(PlayerStateDash));
        if (playerController.isGround == false)
            stateMachine.SwitchState(typeof(PlayerStateInAir));
    }
    public override void Exit()
    {
        
    }

}

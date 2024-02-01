using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerStateRun : PlayerState
{
    public override void Enter()
    {
        //放动画！
        // animator.Play("Run");
    }
    public override void PhysicUpdate()
    {
        //临时性的移动措施
        if(Input.GetKey(KeyCode.RightArrow))
            stateMachine.GetComponent<Rigidbody2D>().velocity = new Vector2(5,0);
        else if(Input.GetKey(KeyCode.LeftArrow))
            stateMachine.GetComponent<Rigidbody2D>().velocity = new Vector2(-5,0);
    }
    public override void LogicUpdate()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            stateMachine.SwitchState(stateMachine.stateIdle);
    }
    public override void Exit()
    {
        
    }

}

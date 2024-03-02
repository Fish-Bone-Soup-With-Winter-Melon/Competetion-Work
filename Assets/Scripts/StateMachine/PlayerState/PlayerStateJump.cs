using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Xml.Xsl;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Jump", fileName = "PlayerState_Jump")]
public class PlayerStateJump : PlayerState
{
    public float xSpeed;
    private float ySpeed;
    public Vector2 velocity;
    private float timeLimit = 0.1f;
    public float time = 0;
    protected void ValueInitialize()
    {
        xSpeed = playerValues.initialVelocity.x;
        ySpeed = playerValues.jumpVelocity.y;
    }
    public override void Enter()
    {
        actionController.Jump();
        rigidbody2D.velocity += new Vector2(0, ySpeed);
        Debug.Log(ySpeed);
        time = 0;
        Debug.Log("Jump");
    }
    public override void LogicUpdate()
    {
        time += Time.deltaTime;
        // Debug.Log(time);
        if (time >= timeLimit)
            stateMachine.SwitchState(typeof(PlayerStateInAir));
    }
    public override void PhysicUpdate()
    {

    }
    public override void Exit()
    {

    }
}

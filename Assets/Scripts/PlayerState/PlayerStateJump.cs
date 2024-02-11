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
    public float timeLimit = 1f;
    public float time = 0;
    public override void Enter()
    {
        // stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(0,ySpeed);
        rigidbody2D.velocity += new Vector2(0,ySpeed);
        time = 0;
    }
    public override void LogicUpdate()
    {
        time += Time.deltaTime;
        if(time >= timeLimit)
            stateMachine.SwitchState(stateMachine.stateInAir);
    }
    public override void PhysicUpdate()
    {
        
    }
    public override void Exit()
    {
        
    }
}

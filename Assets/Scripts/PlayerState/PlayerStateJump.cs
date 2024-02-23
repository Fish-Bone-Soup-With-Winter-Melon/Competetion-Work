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
    private float ySpeed = 5.0f;
    public Vector2 velocity;
    private float timeLimit = 0.1f;
    public float time = 0;
    public override void Enter()
    {
        // stateMachine.GetComponent<Rigidbody2D>().velocity += new Vector2(0,ySpeed);
        rigidbody2D.velocity += new Vector2(0,ySpeed);
        time = 0;
        Debug.Log("Jump");
    }
    public override void LogicUpdate()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if(time >= timeLimit)
            stateMachine.SwitchState(typeof(PlayerStateInAir));
    }
    public override void PhysicUpdate()
    {
        
    }
    public override void Exit()
    {
        
    }
}

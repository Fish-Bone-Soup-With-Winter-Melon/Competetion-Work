using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//a class find out if the gameobject is on the ice or mud
public class PlayerTerrain : MonoBehaviour
{
    public PlayerController playerController;
    // public playerValues playerValues;
    public PlayerValues playerValues;
    public PlayerStateMachine playerStateMachine;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
    }
    void Update()
    {
        if (playerController.isIce)
        {
            playerValues.boostVelocity = new Vector2(6f, 0);
            return;
        }
        else if (playerController.isMud)
        {
            // Debug.Log("Mud");
            playerValues.boostVelocity = new Vector2(-6f, 0);
            return;
        }
        else if (playerController.isGround && playerStateMachine.currentState == playerStateMachine.stateTable[typeof(PlayerStateIdle)])
        {
            // Debug.Log(playerController.isGround);
            // Debug.Log("reset");
            Debug.Log("Reset");
            playerValues.boostVelocity = new Vector2(0, 0);
        }
    }
}

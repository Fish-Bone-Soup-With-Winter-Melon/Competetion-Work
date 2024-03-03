using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//a class find out if the gameobject is on the ice or mud
public class PlayerTerrain : MonoBehaviour
{
    public PlayerController playerController;
    // public playerValues playerValues;
    public PlayerValues playerValues;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (playerController.isGround)
        {
            if (playerController.isIce)
            {
                playerValues.boostVelocity = new Vector2(3f, 0);
            }
            else if (playerController.isMud)
            {
                playerValues.boostVelocity = new Vector2(-3f, 0);
            }
            else
            {
                playerValues.boostVelocity = new Vector2(0, 0);
            }
        }
    }
}

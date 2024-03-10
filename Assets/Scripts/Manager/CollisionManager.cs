using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public PlayerValues playerValues;
    public Rigidbody2D rigidbody2D_1;
    public SceneControllerI sceneController;
    public GameObject gameObject_1;
    // public PlayerStateMachine playerStateMachine;
    public Collider2D collider2D_1;
    public bool isBoost = false;
    public bool isGravityReverse = false;
    public string collisionObjName;
    private float timerBoost = 0;
    private float timerGravityReverse = 0;
    public float effectTimeLimit = 10;
    public PlayerController playerController;
    public Vector2 boostVelocity;
    // public GameObject gameObject_1;    
    void Awake()
    {
        boostVelocity = new Vector2(7, 0);
        timerBoost = 0;
        timerGravityReverse = 0;
        isBoost = false;
        isGravityReverse = false;
        // gameObject = GetComponent<GameObject>();
        rigidbody2D_1 = GetComponent<Rigidbody2D>();
        gameObject_1 = GetComponent<GameObject>();
        sceneController = GetComponent<SceneControllerI>();
        // playerStateMachine = GetComponent<PlayerStateMachine>();
        collider2D_1 = GetComponent<Collider2D>();
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (!isBoost)
        {
            timerBoost = 0;
        }
        if (!isGravityReverse)
        {
            timerGravityReverse = 0;
        }
        // Debug.Log(timer);
        if (isBoost)
        {
            timerBoost += Time.deltaTime;
        }
        if (isGravityReverse)
        {
            timerGravityReverse += Time.deltaTime;
        }
        if (timerBoost >= effectTimeLimit && isBoost)
        {
            playerValues.boostVelocity -= boostVelocity;
            isBoost = false;
        }
        if (timerGravityReverse >= effectTimeLimit && isGravityReverse)
        {
            // Debug.Log("reverse");
            playerValues.gravityScale = Math.Abs(playerValues.gravityScale);
            rigidbody2D_1.gravityScale = playerValues.gravityScale;
            // Debug.Log(playerValues.gravityScale);
            playerValues.jumpVelocity = new Vector2(Math.Abs(playerValues.jumpVelocity.x), Math.Abs(playerValues.jumpVelocity.y));
            playerController.rayLength = Math.Abs(playerController.rayLength);
            rigidbody2D_1.SetRotation(0);
            gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            isGravityReverse = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        collisionObjName = other.gameObject.name;
        switch (collisionObjName)
        {
            case "Keyboard":
                // playerStateMachine.speedBoost = new Vector2(7, 0);
                playerValues.boostVelocity += boostVelocity;
                // effect = Effect.Boost;
                isBoost = true;
                other.gameObject.SetActive(false);
                timerBoost = 0;
                break;
            case "Notebook":
                // effect = Effect.GravityReverse;
                // Debug.Log("GravityReverse");
                isGravityReverse = true;
                rigidbody2D_1.gravityScale = -playerValues.gravityScale;
                playerValues.gravityScale = -playerValues.gravityScale;
                playerValues.jumpVelocity = -playerValues.jumpVelocity;
                other.gameObject.SetActive(false);
                rigidbody2D_1.SetRotation(180);
                playerController.rayLength = -playerController.rayLength;
                //mirror the gameobject
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                timerGravityReverse = 0;
                break;
            case "Sakiko":
                sceneController.LoadScene();
                break;
        }
    }
}

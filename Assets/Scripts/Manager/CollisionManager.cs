using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public PlayerValues playerValues;
    public Rigidbody2D rigidbody2D_1;
    public GameObject gameObject_1;
    public PlayerStateMachine playerStateMachine;
    public Collider2D collider2D_1;
    public enum Effect
    {
        Boost, GravityReverse, Default
    }
    public Effect effect;
    public string collisionObjName;
    private float timer = 0;
    public float effectTimeLimit = 10;
    public PlayerController playerController;
    // public GameObject gameObject_1;    
    void Awake()
    {
        effect = Effect.Default;
        // gameObject = GetComponent<GameObject>();
        rigidbody2D_1 = GetComponent<Rigidbody2D>();
        gameObject_1 = GetComponent<GameObject>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
        collider2D_1 = GetComponent<Collider2D>();
        playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        switch (effect)
        {
            case Effect.Boost:
                timer += Time.deltaTime;
                break;
            case Effect.GravityReverse:
                timer += Time.deltaTime;
                break;
        }
        if (timer >= effectTimeLimit && effect != Effect.Default)
        {
            playerStateMachine.speedBoost = new Vector2(0, 0);
            playerValues.gravityScale = -playerValues.gravityScale;
            Debug.Log("reverse");
            rigidbody2D_1.gravityScale = playerValues.gravityScale;
            playerValues.jumpVelocity = -playerValues.jumpVelocity;
            playerController.rayLength = Math.Abs(playerController.rayLength);
            rigidbody2D_1.SetRotation(0);
            if(effect == Effect.GravityReverse)
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

            effect = Effect.Default;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        collisionObjName = other.gameObject.name;
        switch (collisionObjName)
        {
            case "Keyboard":
                playerStateMachine.speedBoost = new Vector2(4, 0);
                effect = Effect.Boost;
                other.gameObject.SetActive(false);
                timer = 0;
                break;
            case "Notebook":
                effect = Effect.GravityReverse;
                Debug.Log("GravityReverse");
                rigidbody2D_1.gravityScale = -playerValues.gravityScale;
                playerValues.gravityScale = -playerValues.gravityScale;
                playerValues.jumpVelocity = -playerValues.jumpVelocity;
                other.gameObject.SetActive(false);
                rigidbody2D_1.SetRotation(180);
                playerController.rayLength = -playerController.rayLength;
                //mirror the gameobject
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                timer = 0;
                break;
        }
    }
}

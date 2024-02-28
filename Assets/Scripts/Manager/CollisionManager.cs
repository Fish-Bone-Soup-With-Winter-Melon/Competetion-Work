using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public Rigidbody2D rigidbody2D_1;
    public GameObject gameObject_1;
    public PlayerStateMachine playerStateMachine;
    public Collider2D collider2D_1;
    public enum Effect
    {
        Boost,GravityReverse,Default
    }
    public Effect effect;
    public string collisionObjName;
    private float timer = 0;
    public float effectTimeLimit = 10;
    void Awake()
    {
        rigidbody2D_1 = GetComponent<Rigidbody2D>();
        gameObject_1 = GetComponent<GameObject>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
        collider2D_1 = GetComponent<Collider2D>();
    }
    void Update()
    {
        switch(effect)
        {
            case Effect.Boost:
                timer += Time.deltaTime;
                break;
        }
        if (timer >= effectTimeLimit)
        {
            playerStateMachine.speedBoost = new Vector2(0,0);
            rigidbody2D_1.gravityScale = 1;
            effect = Effect.Default;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        collisionObjName = other.gameObject.name;
        switch(collisionObjName)
        {
            case "Keyboard":
                playerStateMachine.speedBoost = new Vector2(4,0);
                effect = Effect.Boost;
                other.gameObject.SetActive(false);
                timer = 0;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStateMachine : StateMachine
{
    Animator animator;
    public BlankState blankState;
    public GameObject itemObject;
    public Rigidbody2D itemRigidbody;
    // Start is called before the first frame update
    protected override void Start()
    {
        currentState = blankState;
    }

    // Update is called once per frame
    void Awake()
    {
        itemRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        // stateIdle.Initialize(animator, this);
        // stateRun.Initialize(animator, this);
        // stateJump.Initialize(animator, this);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStateMachine : StateMachine
{
    Animator animator;
    [SerializeField] ItemState[] itemStates;
    public GameObject itemObject;
    public Rigidbody2D itemRigidbody;
    private string objName;
    public GameObject gameObject1;
    // Start is called before the first frame update
    protected override void Start()
    {
        objName = itemObject.name;
        switch(objName)
        {
            case "Keyboard":
                currentState = stateTable[typeof(ItemBoost)];
                Debug.Log("Keyboard");
                break;
            case "Bass":
                currentState = stateTable[typeof(ItemGravityReverse)];
                break;
        }
        SwitchOn(currentState);
    }

    // Update is called once per frame
    void Awake()
    {
        itemRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        gameObject1 = GetComponent<GameObject>();
        foreach(var itemState in itemStates)
        {
            stateTable.Add(itemState.GetType(),itemState);
            itemState.Initialize(animator,this,itemRigidbody,gameObject1);
        }
    }
    // void OnTriggerEnter2D(Collider2D collider2D)
    // {
    //     SwitchState(stateTable[typeof(ItemVanish)]);
    // }
}

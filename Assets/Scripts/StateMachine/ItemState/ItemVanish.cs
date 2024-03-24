using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/ItemState/Vanish", fileName = "Vanish")]
public class ItemVanish : ItemState
{
    public override void Enter()
    {
        gameObject.SetActive(false);
    }
    public override void Exit()
    {
        
    }
}

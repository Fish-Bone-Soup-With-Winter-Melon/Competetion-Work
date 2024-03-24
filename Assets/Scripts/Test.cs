using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerValuesHandler playerValuesHandler;
    void Awake()
    {
        playerValuesHandler = GetComponent<PlayerValuesHandler>();
        playerValuesHandler.AddPlayer("bsy",new Vector2(0,0),new Vector2(0,0));
        playerValuesHandler.ValuesToJson();
        playerValuesHandler.JsonToValues();
        // Debug.Log(playerValuesHandler.GetPlayerByName("bsy").playerName);
    }
}

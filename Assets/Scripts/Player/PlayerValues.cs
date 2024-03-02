using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using LitJson;
using System.Text;
using System.IO;

public class PlayerValues : Values
{
    public string playerName;
    public bool isPlayerCreated = false;
    public bool isJumpBoosted = false;
    public float jumpBoostedTime = 0.0f;
    public float gravityScale = 3;
    public Vector2 jumpVelocity = new Vector2(0, 25);
    public float dashSpeed;
    public float dashTimeLimit;
    public Vector2 initialVelocity = new Vector2(5,0);

    public PlayerValues()//Only for JsonToValue
    {
        currentState = typeof(PlayerStateNull).ToString();
    }
    public PlayerValues(string playerName, Vector2 velocity, Vector2 coordinate)
    {
        this.playerName = playerName;
        this.curVelocity = velocity;
        this.coordinate = coordinate;
        this.isPlayerCreated = true;
    }


}
public class AllPlayerValues
{
    public List<PlayerValues> valueList;
    public AllPlayerValues()
    {
        valueList = new List<PlayerValues> { };
    }
    public void AddPlayer(PlayerValues player)
    {
        valueList.Add(player);
    }
    public void AddPlayer(string playerName, Vector2 velocity, Vector2 coordinate)
    {
        valueList.Add(new PlayerValues(playerName, velocity, coordinate));
    }
}

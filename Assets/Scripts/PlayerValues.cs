using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using LitJson;
using System.Text;
using System.IO;

public class PlayerValues
{
    public string playerName;
    public bool isPlayerCreated = false;
    public Vector2 velocity = new Vector2(0, 0);
    public Vector2 coordinate;// 坐标
    public IState currentState;
    public bool isJumpBoosted = false;
    public float jumpBoostedTime = 0.0f;
    public PlayerValues(string playerName, Vector2 velocity, Vector2 coordinate)
    {
        this.playerName = playerName;
        this.velocity = velocity;
        this.coordinate = coordinate;
    }

}
public class AllPlayerValues
{
    public List<PlayerValues> valueList;
    public AllPlayerValues(PlayerValues aPlayer, PlayerValues bPlayer, PlayerValues cPlayer)
    {
        valueList = new List<PlayerValues>
        {
            aPlayer,
            bPlayer,
            cPlayer
        };
    }
}
public class PlayerValuesHandler
{
    public PlayerValues aPlayer, bPlayer, cPlayer;
    AllPlayerValues allPlayerValues;

    public PlayerValuesHandler(PlayerValues aPlayer, PlayerValues bPlayer, PlayerValues cPlayer)
    {
        this.aPlayer = aPlayer;
        this.bPlayer = bPlayer;
        this.cPlayer = cPlayer;
        allPlayerValues = new AllPlayerValues(aPlayer,bPlayer,cPlayer);
    }
    public void ValuesToJson()
    {
        StringBuilder sb = new StringBuilder();
        JsonWriter jr = new JsonWriter(sb);
        jr.PrettyPrint = true;
        jr.IndentValue = 4;
        JsonMapper.ToJson(this.allPlayerValues, jr);
        File.WriteAllText(Application.dataPath + "/Resources/PlayerValues.json", sb.ToString());
        return;
    }
    public PlayerValues GetPlayerByName(string playerName)
    {
        if (this.allPlayerValues == null)
        {
            return null;
        }
        else
        {
            var m = allPlayerValues.valueList.Where(item => item.playerName == playerName);
            return m.FirstOrDefault();
        }
    }
}
/*
注意事项：
为了解决存储上的问题，PlayerValues 中成员 currentState 使用 string 类型存储数据，请做好相关类型转换
并且后继开发时一定将任何复杂对象都转化为容易被 json 储存的类型后再进行存储
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using LitJson;
using System.Text;
using System.IO;


public class PlayerValuesHandler : MonoBehaviour
{
    AllPlayerValues allPlayerValues;
    void Awake()
    {
        allPlayerValues = new AllPlayerValues();
    }
    public PlayerValues AddPlayer(string playerName, Vector2 velocity, Vector2 position)
    {
        PlayerValues newPlayer = new PlayerValues(playerName, velocity, position)
        {
            currentState = typeof(PlayerStateNull).ToString()
        };
        allPlayerValues.AddPlayer(newPlayer);
        return newPlayer;
    }
    public PlayerValues AddPlayer(PlayerValues playerValues)
    {
        allPlayerValues.AddPlayer(playerValues);
        return playerValues;
    }
    public void ValueSave(Vector2 velocity, Vector2 position, System.Type currentState,PlayerValues player)
    {
        player.curVelocity = velocity;
        player.position = position;
        player.currentState = currentState.ToString();
    }
    public void ValueSave(Vector2 velocity, Vector2 position, System.Type currentState, bool isJumpBoosted, float jumpBoostedTime,PlayerValues player)
    {
        player.curVelocity = velocity;
        player.position = position;
        player.currentState = currentState.ToString();
        player.isJumpBoosted = isJumpBoosted;
        player.jumpBoostedTime = jumpBoostedTime;
    }
    [ContextMenu("SavePlayer")]
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
    [ContextMenu("LoadPlayer")]
    public void JsonToValues()
    {
        JsonReader jr = new JsonReader(File.ReadAllText(Application.dataPath + "/Resources/PlayerValues.json"));
        AllPlayerValues allPlayerValues = JsonMapper.ToObject<AllPlayerValues>(jr);
        this.allPlayerValues = allPlayerValues;
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

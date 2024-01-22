using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int player_id;                  //player的唯一标识符，饼：多player
    public GameObject player_obj;   //player对应的obj or prefeb，下述函数应当直接操作player_obj的属性
    float speed;                    //设置初始速度（直接改变速度：泥潭）
    float accelerate;               //设置初始加速度（直接改变加速度：冰面）

    public UIManager uiManager;
    public PropManager propManager;

    void Move()
    {
        // 处理玩家的移动逻辑
    }

    void Jump()
    {
        // 处理玩家的跳跃逻辑
    }

    void Dash()
    {
        // 处理玩家的冲刺逻辑
    }

    public void CheckCollision()
    {
        // 检测玩家与地图元素的碰撞
    }
}

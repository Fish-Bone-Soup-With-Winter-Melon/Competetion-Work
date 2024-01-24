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
    private LayerMask GroundLayer;
    private LayerMask IceLayer;
    private LayerMask MudLayer;

    private bool isGround;
    private bool isIce;
    private bool isMud;

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
        Vector2 player_pos = this.transform.position;
        isGround = Physics2D.OverLapCircle(player_pos, 0.1f, GroundLayer);         //检测逻辑：以物体的当前位置为圆心，0.1f为半径，检测是否与GroundLayer相交
        isIce = Physics2D.OverLapCircle(player_pos, 0.1f, IceLayer);              
        isMud = Physics2D.OverLapCircle(player_pos, 0.1f, MudLayer);
        // 检测玩家与地图元素的碰撞

    }
}

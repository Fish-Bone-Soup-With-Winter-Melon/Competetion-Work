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

    public bool isGround;
    public bool isIce;
    public bool isMud;

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
        CheckIsOnHorizontalGround();         //检测逻辑：以物体的当前位置为圆心，0.1f为半径，检测是否与GroundLayer相交
        CheckIsOnHorizontalIce();
        CheckIsOnHorizontalMud();
        // 检测玩家与地图元素的碰撞       //仅限于地图元素不包括碰撞道具的情况
    }

    void OnTriggerEnter2D(Collider2D other)        //检测玩家与道具的碰撞
    {
        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            propManager.CollectProp(PropManager.PropType.SpeedBoost);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("GravityReverse"))
        {
            propManager.CollectProp(PropManager.PropType.GravityReverse);
            Destroy(other.gameObject);
        }
        // 处理玩家与道具的碰撞
    }       //这个理论上应该每帧检测一次





    // 以下为检测玩家与地图元素的碰撞的函数
    public RaycastHit2D CreateOffsetRaycast(Vector2 offset, Vector2 diraction, float length, LayerMask layer)
    {
        // 获得玩家当前坐标位置
        Vector2 playerPosition = transform.position;
        // 生成玩家当前位置水平偏移的射线投射碰撞器
        RaycastHit2D hit = Physics2D.Raycast(playerPosition + offset, diraction, length, layer);
        // 如果于水平地面发生碰撞则显示红色，反之则显示绿色
        Color rayColor = hit ? Color.red : Color.green;
        // 在Scene中动态打印投射出的光线
        Debug.DrawRay(playerPosition + offset, diraction * length, rayColor);
        // 返回生成的检测器
        return hit;
    }

    public void CheckIsOnHorizontalGround(/*int state*/)
    {
        //TODO:STATE


        // 调用(1)中方法，生成玩家左侧检测射线
        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, GroundLayer);
        // 调用(1)中方法，生成玩家右侧检测射线
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, GroundLayer);
        // 判断左右双射线是否与水平地面图层发生碰撞
        if (leftCheckRay || rightCheckRay)
        {
            // 设置地面状态器为真
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    public void CheckIsOnHorizontalIce()
    {
        // 调用(1)中方法，生成玩家左侧检测射线
        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, IceLayer);
        // 调用(1)中方法，生成玩家右侧检测射线
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, IceLayer);
        // 判断左右双射线是否与水平地面图层发生碰撞
        if (leftCheckRay || rightCheckRay)
        {
            // 设置地面状态器为真
            isIce = true;
        }
        else
        {
            isIce = false;
        }
    }

    public void CheckIsOnHorizontalMud()
    {
        // 调用(1)中方法，生成玩家左侧检测射线
        RaycastHit2D leftCheckRay = CreateOffsetRaycast(new Vector2(-0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, MudLayer);
        // 调用(1)中方法，生成玩家右侧检测射线
        RaycastHit2D rightCheckRay = CreateOffsetRaycast(new Vector2(0.5f, 0.0f), new Vector2(-1f, 0.0f), 0.51f, MudLayer);
        // 判断左右双射线是否与水平地面图层发生碰撞
        if (leftCheckRay || rightCheckRay)
        {
            // 设置地面状态器为真
            isMud = true;
        }
        else
        {
            isMud = false;
        }
    }
}

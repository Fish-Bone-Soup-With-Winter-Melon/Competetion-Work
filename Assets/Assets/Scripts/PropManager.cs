using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
    public PlayerController playerController;
    public enum PropType
    {
        SpeedBoost,
        // 添加道具类型
    }
    public void CollectProp(PropType propType)
    {
        switch (propType)
        {
            case PropType.SpeedBoost:
                // 处理速度提升道具的逻辑
                Debug.Log("Collected Speed Boost");
                break;

            // 添加其他道具类型的处理逻辑

            default:
                Debug.LogWarning("Unknown prop type");
                break;
        }
    }
    void SpawnProps(/*Optional:pos*/)
    {
        // 生成游戏中的道具
    }

    void CollectProp(/*Optional:pos*/)
    {
        // 处理玩家收集道具的逻辑
    }
}

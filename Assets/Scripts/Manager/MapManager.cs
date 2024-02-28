using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public PlayerController playerController;
    public PropManager propManager;

    public void GenerateMap()
    {
        TilemapManager tilemapManager = new TilemapManager();
        tilemapManager.Load();
    }

    void UpdateMap()
    {
        // 更新地图，处理地图滚动和变化
    }

    // void CheckCollision()
    // {
    //     // 检测玩家与地图元素的碰撞
    //     // playerController.CheckCollision();
    // }
}


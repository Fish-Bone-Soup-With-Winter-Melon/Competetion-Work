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
        // ���µ�ͼ�������ͼ�����ͱ仯
    }

    // void CheckCollision()
    // {
    //     // ���������ͼԪ�ص���ײ
    //     // playerController.CheckCollision();
    // }
}


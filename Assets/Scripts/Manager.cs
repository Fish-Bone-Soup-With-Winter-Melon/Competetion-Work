using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Manager : MonoBehaviour
{
    public Tilemap Ground, Ice , Mud;
    public List<TileBase> tiles = new List<TileBase>();
    [ContextMenu("save")]

    public void test()
    {
        TileMapHandler Tilemaphandler = new TileMapHandler(Ground , Ice , Mud);
        Tilemaphandler.MapToJson("map_0", new Vector2Int(20 , 11));

    }

    [ContextMenu("Load")]
    public void Load()
    {
        TileMapHandler Tilemaphandler = new TileMapHandler();
        Map map = Tilemaphandler.getMapByName("map_0");
        if(map == null)
        {
            Debug.Log("读取文件失败");
            return;
        }
        foreach (Tile item in map.groundTiles)
        {
            Ground.SetTile(new Vector3Int(item.x, item.y, 0) ,tiles.Where(i => i.name == item.tileName).FirstOrDefault());
        }
        foreach (Tile item in map.iceTiles)
        {
            Ice.SetTile(new Vector3Int(item.x, item.y, 0), tiles.Where(i => i.name == item.tileName).FirstOrDefault());
        }
        foreach (Tile item in map.mudTiles)
        {
            Mud.SetTile(new Vector3Int(item.x, item.y, 0), tiles.Where(i => i.name == item.tileName).FirstOrDefault());
        }                   //挨个读取文件中的tile并且放到对应的tilemap中
    }

    [ContextMenu("clear")]

    public void test2()
    {
        Ground.ClearAllTiles();
        Ice.ClearAllTiles();
        Mud.ClearAllTiles();
    }
}

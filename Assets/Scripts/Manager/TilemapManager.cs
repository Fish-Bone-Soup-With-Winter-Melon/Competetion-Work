using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
// using UnityEditor.Media;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    //Tilemap
    public Tilemap Ground, Ice, Mud;
    public List<TileBase> tiles = new List<TileBase>();
    public PlayerValues aPlayer, bPlayer, cPlayer;
    [ContextMenu("save")]

    public void test()
    {
        TileMapHandler Tilemaphandler = new TileMapHandler(Ground, Ice, Mud);
        Tilemaphandler.MapToJson("map_0", new Vector2Int(28, 16));

    }
    [ContextMenu("Load")]
    public void Load()
    {
        Debug.Log("Load");
        TileMapHandler Tilemaphandler = new TileMapHandler();
        Map map = Tilemaphandler.getMapByName("map_0");
        if (map == null)
        {
            Debug.Log("读取文件失败");
            return;
        }
        foreach (Tile item in map.groundTiles)
        {
            Ground.SetTile(new Vector3Int(item.x, item.y, 0), tiles.Where(i => i.name == item.tileName).FirstOrDefault());
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
        foreach (GameObject obj in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            int x = LayerMask.NameToLayer("Prop");
            if (obj.layer == x)
            {
                GameObject.Destroy(obj);
            }

        }
    }

    [ContextMenu("saveprops")]

    public void test3()
    {
        PropManager propManager = new PropManager();
        propManager.SaveProp();
    }

    [ContextMenu("loadprops")]

    public void test4()
    {
        PropManager propManager = new PropManager();
        propManager.SpawnProps();
    }
    
}



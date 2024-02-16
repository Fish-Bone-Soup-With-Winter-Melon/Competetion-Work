using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using LitJson;
using UnityEngine.TextCore.Text;
using System.Text;

public class TileMapHandler
{
    public Tilemap Ground, Ice , Mud; 
    public TileMapHandler(Tilemap Ground, Tilemap Ice , Tilemap Mud)
    {
        this.Ground = Ground;
        this.Ice = Ice;
        this.Mud = Mud;
    }
    public TileMapHandler()
    {

    }

    public string MapToJson(string mapName , Vector2Int size)
    {
        Map map = new Map();
        map.mapName = mapName;
        for(int i = -14; i < size.x -14; i++)
        {
            for(int j = -8; j < size.y -8; j++)
            {
                TileBase tb = Ground.GetTile(new Vector3Int(i, j, 0));
                if(tb != null){
                    Tile t = new Tile();
                    t.tileName = tb.name;
                    t.x = i;
                    t.y = j;
                    map.groundTiles.Add(t);
                }
            }
        }
        for (int i = -14; i < size.x -14; i++)
        {
            for (int j = -8; j < size.y -8; j++)
            {
                TileBase tb = Ice.GetTile(new Vector3Int(i, j, 0));
                if (tb != null)
                {
                    Tile t = new Tile();
                    t.tileName = tb.name;
                    t.x = i;
                    t.y = j;
                    map.iceTiles.Add(t);
                }
            }
        }
        for (int i = -14; i < size.x -14; i++)
        {
            for (int j = -8; j < size.y -8; j++)
            {
                TileBase tb = Mud.GetTile(new Vector3Int(i, j, 0));
                if (tb != null)
                {
                    Tile t = new Tile();
                    t.tileName = tb.name;
                    t.x = i;
                    t.y = j;
                    map.mudTiles.Add(t);
                }
            }
        }

        UnityEngine.TextAsset textAsset = Resources.Load<UnityEngine.TextAsset>("Maps");
        AllMaps allMaps = JsonMapper.ToObject<AllMaps>(textAsset.text);
        Resources.UnloadAsset(textAsset);
        if(allMaps == null)
        {
            allMaps = new AllMaps();
        }
        else
        {
            var m = allMaps.Maps.Where(item => item.mapName == mapName);
            if(m.Count() > 0)
            {
                allMaps.Maps.Remove(m.FirstOrDefault());
            }
        }
        allMaps.Maps.Add(map);

        StringBuilder sb = new StringBuilder();
        JsonWriter jr = new JsonWriter(sb);
        jr.PrettyPrint = true;//设置为格式化模式，LitJson称其为PrettyPrint（美观的打印），在 Newtonsoft.Json里面则是 Formatting.Indented（锯齿状格式）
        jr.IndentValue = 4;//缩进空格个数
        JsonMapper.ToJson(allMaps, jr);
        File.WriteAllText(Application.dataPath+"/Resources/Maps.json", sb.ToString());
        return sb.ToString();
    }
    public Map getMapByName(string mapName) {

        string json = File.ReadAllText(Application.dataPath + "/Resources/Maps.json");
        AllMaps allMaps = JsonMapper.ToObject<AllMaps>(json);
        if(allMaps == null)
        {
            return null;
        }
        else
        {
            var m = allMaps.Maps.Where(item => item.mapName == mapName);
            return m.FirstOrDefault();
        }
    }
}

public class AllMaps {
    public List<Map> Maps = new List<Map>();
}

public class Map  {
    public string mapName;
    public List<Tile> groundTiles = new List<Tile>();
    public List<Tile> iceTiles = new List<Tile>();
    public List<Tile> mudTiles = new List<Tile>();
}

public class Tile {
    public string tileName;
    public int x, y;
}



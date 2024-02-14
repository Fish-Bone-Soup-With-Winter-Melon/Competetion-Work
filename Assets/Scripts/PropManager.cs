using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using System.Text;
using System.Linq;
using System.ComponentModel;

public class PropManager : MonoBehaviour
{
    public PlayerController playerController;
    public enum PropType
    {
        SpeedBoost,GravityReverse,
        // ��ӵ�������
    }
    public void CollectProp(PropType propType)
    {
        switch (propType)
        {
            case PropType.SpeedBoost:
                // �����ٶ��������ߵ��߼�
                Debug.Log("Collected Speed Boost");
                break;

            // ��������������͵Ĵ����߼�

            default:
                Debug.LogWarning("Unknown prop type");
                break;
        }
    }
    public void SpawnProps(/*Optional:pos*/)         // ������Ϸ�еĵ���
    {
        SpriteData spriteData = LoadSpriteData(Application.dataPath + "/Resources/Props.json");
        PlaceSprites(spriteData);
    }

    void CollectProp(/*Optional:pos*/)
    {
        // ��������ռ����ߵ��߼�
    }

    public SpriteData LoadSpriteData(string path)              //��ָ��·����ȡSprite��Ϣ
    {
        string json = File.ReadAllText(path);
        SpriteData spriteData = JsonMapper.ToObject<SpriteData>(json);
        if (json != null)
        {
            return spriteData;
        }
        else
        {
            Debug.LogError("Unable to load sprite data.");
            return null;
        }
    }

    // ͨ�����Ƽ��ص��ߵ���ͼ
    private Sprite GetSpriteByName(string name)
    {
        return Resources.Load<Sprite>("props/" + name);//Ĭ�ϵ�����ͼ�ļ��洢��Resouces/props�ļ�����
    }

    void PlaceSprites(SpriteData spriteData)         //������Ҫ��ÿ������λ�ðڷŵ��õĺ���
    {
        foreach (SpriteInfo spriteInfo in spriteData.sprites)
        {
            Sprite sprite = GetSpriteByName(spriteInfo.name);

            if (sprite != null)
            {
                GameObject spriteObject = new GameObject(spriteInfo.name);
                SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = sprite;

                // ����λ��
                spriteObject.transform.position = spriteInfo.pos;
                spriteObject.layer = spriteInfo.layer;
                spriteObject.tag = spriteInfo.tag;
            }
        }
    }

    //����Ϊ��ȡȫ��Gameobject ���ұ������в㼶Ϊprop�����壬��ȡλ�ú����ƽ��䴢�浽json�ļ��еķ���

    public string PropToJson()
    {
        int x = LayerMask.NameToLayer("Prop");
        List<SpriteInfo> spriteInfos = new List<SpriteInfo>();
        foreach (GameObject obj in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.layer == x)
            {
                SpriteInfo info = new SpriteInfo
                {
                    pos = obj.transform.position,
                    name = obj.name,
                    layer = obj.layer,
                    tag = obj.tag
                };
                spriteInfos.Add(info);
            }
        }
        SpriteData spriteData = new SpriteData
        {
            sprites = spriteInfos.ToArray()
        };

        StringBuilder sb = new StringBuilder();
        JsonWriter jr = new JsonWriter(sb);
        jr.PrettyPrint = true;//����Ϊ��ʽ��ģʽ��LitJson����ΪPrettyPrint�����۵Ĵ�ӡ������ Newtonsoft.Json�������� Formatting.Indented�����״��ʽ��
        jr.IndentValue = 4;//�����ո����
        JsonMapper.ToJson(spriteData, jr);
        return sb.ToString();
    }
    //��Ҫ��ʱ����øú�������������Ϣ�����json�ļ���
    public void SaveProp()
    {
        string json = PropToJson();
        File.WriteAllText(Application.dataPath + "/Resources/Props.json", json);
    }

}

//�洢������Ϣ�����ݽṹ-------------------------------------------------------------

public class SpriteInfo
{
    public Vector3 pos;
    public string name;
    public int layer;
    public string tag;
}

public class SpriteData
{
    public SpriteInfo[] sprites;
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
    public PlayerController playerController;
    public enum PropType
    {
        SpeedBoost,
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
    void SpawnProps(/*Optional:pos*/)
    {
        // ������Ϸ�еĵ���
    }

    void CollectProp(/*Optional:pos*/)
    {
        // ��������ռ����ߵ��߼�
    }
}

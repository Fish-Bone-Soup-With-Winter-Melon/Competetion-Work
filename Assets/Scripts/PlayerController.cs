using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int player_id;                  //player��Ψһ��ʶ����������player
    public GameObject player_obj;   //player��Ӧ��obj or prefeb����������Ӧ��ֱ�Ӳ���player_obj������
    float speed;                    //���ó�ʼ�ٶȣ�ֱ�Ӹı��ٶȣ���̶��
    float accelerate;               //���ó�ʼ���ٶȣ�ֱ�Ӹı���ٶȣ����棩

    public UIManager uiManager;
    public PropManager propManager;

    void Move()
    {
        // ������ҵ��ƶ��߼�
    }

    void Jump()
    {
        // ������ҵ���Ծ�߼�
    }

    void Dash()
    {
        // ������ҵĳ���߼�
    }

    public void CheckCollision()
    {
        // ���������ͼԪ�ص���ײ
    }
}

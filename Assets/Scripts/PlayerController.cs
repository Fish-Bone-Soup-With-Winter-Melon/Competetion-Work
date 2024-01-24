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
    private LayerMask GroundLayer;
    private LayerMask IceLayer;
    private LayerMask MudLayer;

    private bool isGround;
    private bool isIce;
    private bool isMud;

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
        Vector2 player_pos = this.transform.position;
        isGround = Physics2D.OverLapCircle(player_pos, 0.1f, GroundLayer);         //����߼���������ĵ�ǰλ��ΪԲ�ģ�0.1fΪ�뾶������Ƿ���GroundLayer�ཻ
        isIce = Physics2D.OverLapCircle(player_pos, 0.1f, IceLayer);              
        isMud = Physics2D.OverLapCircle(player_pos, 0.1f, MudLayer);
        // ���������ͼԪ�ص���ײ

    }
}

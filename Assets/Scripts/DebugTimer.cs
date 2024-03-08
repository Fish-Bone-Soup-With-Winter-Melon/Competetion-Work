using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTimer : MonoBehaviour
{
    public float timer;
    public PlayerController playerController;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.1)
        {
            timer = 0;
            Debug.Log(playerController.isGround);
        }
    }
}

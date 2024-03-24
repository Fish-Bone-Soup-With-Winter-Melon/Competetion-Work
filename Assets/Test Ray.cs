using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay : MonoBehaviour
{
    PlayerController playerController;
    public Vector3 forward = new Vector3(0 , -10 , 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray2D ray = new Ray2D(transform.position, forward);
        Debug.DrawLine(transform.position, transform.position + forward, Color.red);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPC : MonoBehaviour
{
    public int speed;
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        // передвижение персонажа
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            var v = new Vector3(x, 0.0f, z);
            transform.position += v * speed * Time.deltaTime;
        }
    }
}
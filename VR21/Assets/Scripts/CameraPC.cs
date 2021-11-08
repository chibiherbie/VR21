using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPC : MonoBehaviour
{
    public GameObject player; // тут объект игрока
    private Vector3 offset;
    public GameObject Cam;
    public float RotY;
    public float RotX;
    public Camera cameraTr;

    private PhotonView photonView;
    void Start()
    {
        offset = transform.position - player.transform.position;
        if (!(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor))
        {
            Cam.gameObject.SetActive(false);
        }
        Cursor.visible = false;
    }

    private void Update()
    {
        MoveCam();
    }

    private void MoveCam()
    {
        RotY += Input.GetAxis("Mouse Y");
        RotX += Input.GetAxis("Mouse X");

        if (RotY < 18 && RotY > -45)
        { 
            cameraTr.transform.rotation = Quaternion.Euler(-RotY, RotX, 0f);   
        }
    }

}

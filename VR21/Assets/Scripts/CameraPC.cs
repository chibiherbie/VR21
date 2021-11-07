using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPC : MonoBehaviour
{
    public GameObject player; // тут объект игрока
    private Vector3 offset;
    public GameObject Cam;

    private PhotonView photonView;
    void Start()
    {
        offset = transform.position - player.transform.position;
        if (!(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor))
        {
            Cam.gameObject.SetActive(false);
        }
    }
        
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

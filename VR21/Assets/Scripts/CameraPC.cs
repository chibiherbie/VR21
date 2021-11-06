using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPC : MonoBehaviour
{
    public GameObject player; // тут объект игрока
    private Vector3 offset;

    private PhotonView photonView;
    void Start()
    {
        offset = transform.position - player.transform.position;
        if (!photonView.IsMine)
        {
            Destroy(Camera.main);
        }
    }
        
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{

    private GameObject spawnedPlayerPrefab;
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("Connected PC.");
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Player PC", transform.position, transform.rotation);
        }
        else
        {
            Debug.Log("Connected VR.");
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("VR", transform.position, transform.rotation);
        }

    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}
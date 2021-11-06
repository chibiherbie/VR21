using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class TypePlayer : MonoBehaviour
{
    
    public GameObject VR;
    public GameObject PC;

    
    void Awake()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("Connected PC.");
            Instantiate(PC, transform.position, transform.rotation);
        }
        else
        {
            Debug.Log("Connected VR.");
            Instantiate(VR, transform.position, transform.rotation);
        }
    }
}

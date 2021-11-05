using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;

public class PlayerVR : MonoBehaviour
{

    public GameObject human;

    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;

    private float flyingspeed = 0.5f;
    private bool isFlying = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0.3 && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0.3)
        {   
            Debug.Log("Нажал левый и правый");
            Instantiate(human, transform.position, transform.rotation);
        }
        else
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
            {
                FlyL(); 
            }
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                FlyR();
            }
        }
    }

    private void CheckFlying()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            isFlying = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            isFlying = false;
        }
    }

    private void FlyL()
    {

            Vector3 flyDirection = leftHand.transform.position - head.transform.position;
            transform.position += flyDirection.normalized * OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        
    }
    private void FlyR()
    {
  
            Vector3 flyDirection = rightHand.transform.position - head.transform.position;
            transform.position += flyDirection.normalized * OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        
    }
}

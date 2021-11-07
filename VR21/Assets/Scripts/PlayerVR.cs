using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerVR : MonoBehaviour
{
    public Text log; // log

    public GameObject human;

    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject playerVR;
    public GameObject Head;
    public Transform trackingSpace; // reference to the tracking space

    private float scale;
    private float DistanceHand;

    Vector3 positionR = new Vector3();
    Vector3 positionL = new Vector3();
    private bool StaticPosition;

    private bool isFlying = false;

    bool CanRotate;

    private PhotonView photonView;
    void Start()
    {
        StaticPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            Head.gameObject.SetActive(false);
        }

        RotateCam();

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0.3 && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0.3
            && !isFlying)
        {
            if (!StaticPosition)
            {
                OrigCoord();
                StaticPosition = true;
            }

            Debug.Log("Нажал левый и правый");
            //Instantiate(human, transform.position, transform.rotation);
            ChangeSizeVR();
        }
        else
        {
            isFlying = false;
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
            {
                FlyL();
                isFlying = true;
            }
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                FlyR();
                isFlying = true;
            }
        }

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) <= 0.1 && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) <= 0.1)
        {
            StaticPosition = false;
        }
    }

    private void RotateCam()
    {
        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);

        if (primaryAxis.x > 0 && CanRotate)
        {
            transform.Rotate(Vector3.up, 90);
        }
        if (primaryAxis.x < 0 && CanRotate)
        {
            transform.Rotate(Vector3.up, -90);
        }

        CanRotate = true;
        if (primaryAxis.x != 0)
        {
            CanRotate = false;
        }
    }

    private int CircleRotate()
    {   
        int num = 10;
        return num;
    }

    private void OrigCoord()
    {
        Vector3 positionR = trackingSpace.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch));
        Vector3 rotationR = trackingSpace.TransformDirection(OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).eulerAngles);
        Vector3 positionL = trackingSpace.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch));
        Vector3 rotationL = trackingSpace.TransformDirection(OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).eulerAngles);
        DistanceHand = point(positionR, positionL);
    }
    private void ChangeSizeVR()
    {
        //scale = (point(positionR, trackingSpace.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch))) +
        //   point(positionL, trackingSpace.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch)))) / 400;
        scale = (DistanceHand - point(trackingSpace.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)),
            trackingSpace.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch)))) / 2;
        Debug.Log(trackingSpace.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch)));
        //log.text = scale.ToString();
        playerVR.transform.localScale += new Vector3(scale, scale, scale);
    }

    private float point(Vector3 first, Vector3 second)
    {
        return Mathf.Sqrt(Mathf.Pow(second.x - first.x, 2) + Mathf.Pow(second.z - first.z, 2));
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
        transform.position += flyDirection.normalized * (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) / 1.5f);
    }

    private void FlyR()
    {
        Vector3 flyDirection = rightHand.transform.position - head.transform.position;
        transform.position += flyDirection.normalized * (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) / 1.5f);
    }
}

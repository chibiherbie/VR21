using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;

public class Back : MonoBehaviour
{
    public GameObject human;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(OVRInput.Controller other)
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0.3)
        {
            Instantiate(human, transform.position, transform.rotation);
        }
    }
}

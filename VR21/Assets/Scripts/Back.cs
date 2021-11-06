using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static OVRInput;

public class Back : MonoBehaviour
{
    public GameObject Obj;
    private bool TakeOne;
    GameObject ObjCreate;

    public GameObject leftHand;
    public GameObject rightHand;

    public Collider[] Current;
    Collider[] OutZone;
    Collider[] InZone;

    public Text log;
    // Start is called before the first frame update
    void Start()
    {
        TakeOne = true;
        ObjCreate = null;
    }

    // Update is called once per frame
    /*
   private void FixedUpdate()
   {   

       InZone = Physics.OverlapSphere(this.transform.position, 0.3f);
       foreach (var coll in InZone)
       {
           Debug.Log("Сфера");
           if (ObjCreate == null)
           {
               ObjCreate = Instantiate(Obj, rightHand.transform.position, rightHand.transform.rotation);
           }

           if (TakeOne)
           {
               ObjCreate.transform.position = rightHand.transform.position;
           }

           if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0.3 && TakeOne)
           {
               log.text = "Создал";
               TakeOne = false;
           }
       }

       OutZone = Current.Except(InZone).ToArray();

       foreach (var cube in OutZone)
       {
           Debug.Log("no Сфера");
           if (TakeOne)
           {
               Destroy(ObjCreate);
           }

           TakeOne = true;
           ObjCreate = null;
           log.text = "Вышел";
       }
   }

   private void OnDrawGizmos()
   {
       Gizmos.DrawWireSphere(this.GetComponent<Collider>().transform.position, 0.3f);
   }
       */

    /*
    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Hand")
        {
            log.text = "В зоне";
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand") { 
            if (ObjCreate == null && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) == 0)
            {
                ObjCreate = Instantiate(Obj, rightHand.transform.position, rightHand.transform.rotation);
            }

            if (TakeOne)
            {
                ObjCreate.transform.position = rightHand.transform.position;
            }

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0.3 && TakeOne)
            {
                log.text = "Создал";
                TakeOne = false;
            }
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0.3 && TakeOne)
            {
                log.text = "Создал";
                TakeOne = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            if (TakeOne)
            {
                Destroy(ObjCreate);
            }

            TakeOne = true;
            ObjCreate = null;
            log.text = "Вышел";
        }
    }
    */
}

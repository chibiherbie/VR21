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

    private void OnTriggerStay(Collider other)
    {
        if ( other.CompareTag("Hand"))
        {
            Instantiate(human, transform.position, transform.rotation);
        }
    }
}

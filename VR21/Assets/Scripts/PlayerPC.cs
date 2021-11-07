using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { PlusPosition, ForseRigidbody }

public class PlayerPC : MonoBehaviour
{
    public Type TypeOf;
    public Transform player;
    public int speed;
    public int forse = 10;
    public Rigidbody rb;
    public bool is_grounded =  true;


    public AudioClip CoinFX;

    public float Rot;
    
    private readonly Vector3 jumpDirection = Vector3.up;
    
    private void Start()
    {
        player = transform;
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    private void Update()
    {
        if(TypeOf == Type.PlusPosition)
        {
            if(Input.GetKey(KeyCode.W))
            {
                player.position += player.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.position -= player.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                player.position += player.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                player.position -= player.right * speed * Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {       
            this.Jump();
        }

        MouseMove();

    }



    private void MouseMove()
    {
        Rot += Input.GetAxis("Mouse X");

        player.transform.rotation = Quaternion.Euler(0f, Rot, 0f);
    }

    private void Jump()
    {
        if (this.is_grounded)
            rb.AddForce(Vector3.up * forse, ForceMode.Impulse);
            
    }

    private void OnCollisionEnter(Collision other)
    {
        var ground = other.gameObject.CompareTag("ground");
        if (ground)
            this.is_grounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        var ground = other.gameObject.CompareTag("ground"); 
        if (ground)
            this.is_grounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);

        }
    }

}

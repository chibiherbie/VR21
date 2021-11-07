using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { PlusPosition, ForseRigidbody }

public class PlayerPC : MonoBehaviour
{
    /*Rigidbody player;
    public float forse = 6;
    public int speed;
    private PhotonView photonView;
    void Start()
    {
        speed = 5;
        photonView = GetComponent<PhotonView>();
        player = GetComponent<Rigidbody>();
    }

    bool is_ground = true;
    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("ground")) is_ground = true;
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("ground")) is_ground = false;
    }

    // Update is called once per frame
    void Update()
    {
        // передвижение персонажа
        if (photonView.IsMine)
        {

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");
                var v = new Vector3(x, 0.0f, z);
                transform.position += v * speed * Time.deltaTime;
            } 
        }
        
        // jump pc Player
        if (photonView.IsMine)
        {

            if (Input.GetKeyDown(KeyCode.Space) && is_ground)
            {
                player.AddForce(Vector3.up * forse, ForceMode.Impulse);
                //float x = Input.GetAxis("Horizontal");
                //float z = Input.GetAxis("Vertical");
                //var v = new Vector3(x, 0.0f, z);
                //photonView.AddForse(Vector2.up * forse);
                //transform.position += v * speed * Time.deltaTime;
                //transform.Translate(Vector3.up * -3.0f * Time.deltaTime , Space.World);
            }
        }


    }*/

    public Type TypeOf;
    public Transform player;
    public int speed;
    public int jump;
    public Rigidbody rb;
    
    private void Start()
    {
        player = transform;
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
        {        //если нажата кнопка "пробел" и игрок на земле
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);  //то придаем ему силу вверх импульсным пинком
        }



        /*else
        {
            if (Input.GetKey(KeyCode.W))
            {
                
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
        }*/
    }

}

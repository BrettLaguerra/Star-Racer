using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public int score = 0;

    [ServerCallback]
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Star")
        {
            score++;
            Debug.Log(score);
        }
        if (other.gameObject.tag == "WallN")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z * -.99f);
        }
        if (other.gameObject.tag == "WallW")
        {
            transform.position = new Vector3(transform.position.x * -.99f, transform.position.y, transform.position.z);
        }
        
    }
    void HandleMovement()
    {
        if (isLocalPlayer)
        {
            float lookX = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");
            float moveHorizontal = Input.GetAxisRaw("Strafe");

            transform.Rotate(Vector3.up * lookX * 2);  

            Vector3 movement = transform.right * moveHorizontal *.1f + transform.forward * moveVertical * .1f;
            transform.position = transform.position + movement;
        }
    }
    

    void FixedUpdate()
    {
        HandleMovement();
    }
}

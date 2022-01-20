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
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * .2f, 0, moveVertical * .2f);
            transform.position = transform.position + movement;

        }
    }
    

    void FixedUpdate()
    {
        HandleMovement();
    }
}

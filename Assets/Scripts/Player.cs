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
        Debug.Log("Collision Detected");
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

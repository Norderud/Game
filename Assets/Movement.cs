using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float speed = 12f;
    public float jumpHeight = 1f;
    private float gravityValue = -9.81f;

    private void Start()
    {
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; 
        controller.Move(move * (speed * Time.deltaTime));
        
        if(Input.GetButtonDown("Jump")){
            if (groundedPlayer)
            {
                Debug.Log("Should be jumpih");
                playerVelocity.y += jumpHeight;
            }
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
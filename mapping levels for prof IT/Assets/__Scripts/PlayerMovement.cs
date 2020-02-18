using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	 public CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		 if (characterController.isGrounded)
        {

	
			Vector3 move = transform.right * Input.GetAxis("Horizontal")+transform.forward*Input.GetAxis("Vertical");
            move *= speed;
			characterController.Move(move*speed*Time.deltaTime);
			
			if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float speed=1.0f;
    [SerializeField] private float jumpforce;
    [SerializeField] private float raycastDistance;

    private Rigidbody rb;

    private void Start()
    {
        rb=GetComponent<Rigidbody>();

    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate() //happens every physics step rather than every frame
    {
        Move();
    }

    private void Move()
    {
        float hAxis=Input.GetAxisRaw("Horizontal");
        float vAxis=Input.GetAxisRaw("Vertical");

        Vector3 movement=new Vector3(hAxis,0,vAxis)*speed*Time.fixedDeltaTime;

        Vector3 newPosition=rb.position+rb.transform.TransformDirection(movement); //moves the player toward where they are looking
        rb.MovePosition(newPosition);
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(IsGrounded())
            {
                rb.AddForce(0,jumpforce,0,ForceMode.Impulse);
            }
            
        }
    }

    private bool IsGrounded() //checks if the capsule is on the ground
    {   
        return Physics.Raycast(transform.position,Vector3.down,raycastDistance); //boolean
        
    }
}

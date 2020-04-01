using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    [SerializeField] private float lookSensitivity;
    [SerializeField] private float smoothing;
    [SerializeField] private int maxLookRotation;
    private GameObject player;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPos;
    // Start is called before the first frame update
    void Start()
    {
        player=transform.parent.gameObject;
        Cursor.lockState=CursorLockMode.Locked;//locks cursor in center of screen
        Cursor.visible=false; //player is the parent of this game object
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        
        
    }

    private void RotateCamera()
    {   
        //storing input
        Vector2 inputValues=new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //scale these values to our input sensitivity and smoothing
        inputValues=Vector2.Scale(inputValues, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));

        //makes camera movement less jumpy
        //smooths the input values so that the camera doesnt instant pan to where the mouse moves
        //the more smoothing the slower the camera moves
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValues.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValues.y, 1f / smoothing);

        currentLookingPos+=smoothedVelocity;

        //constrict the range of which the player can look up/down
        currentLookingPos.y=Mathf.Clamp(currentLookingPos.y,-maxLookRotation,maxLookRotation);

        //when we look up/down the camera rotates 
        transform.localRotation= Quaternion.AngleAxis(-currentLookingPos.y, Vector3.right);
        
        //when we look left or right then we want the player to rotate
        player.transform.localRotation=Quaternion.AngleAxis(currentLookingPos.x,player.transform.up);
    }

    
}

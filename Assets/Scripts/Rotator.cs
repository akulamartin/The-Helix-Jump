using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationspeed;
    // Start is called before the first frame update
    void Start()
    {
       //Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!theGameManager.isGameStarted)
        {
            return;
        }
        
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0,-mouseX * rotationspeed * Time.deltaTime,0);
        }
        
        if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            float xDelta = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(0,-xDelta * rotationspeed * Time.deltaTime,0);   
        }
    }
}

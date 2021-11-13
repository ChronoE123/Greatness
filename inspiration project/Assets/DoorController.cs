using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public bool characterInArea;

    // Start is called before the first frame update
    void Start()
    {
        Input_controller.current.onDoorwayTriggerEnter += onDoorWayOpen;
        Input_controller.current.onDoorwayTriggerExit += onDoorWayClose;
    }

    public void onDoorWayClose()
    {
       
            gameObject.transform.position = new Vector3(-0.07f, 1.58f, 7.34f);
       
       
    }

    public void onDoorWayOpen()
    {
       
            gameObject.transform.position = new Vector3(-0.07f, 5.88f, 7.34f);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Input_controller.current.DoorwayTriggerEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        Input_controller.current.DoorwayTriggerExit();
    }
}

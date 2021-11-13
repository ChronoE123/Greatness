using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class MoveInputEvent : UnityEvent<float,float> { }

[Serializable]
public class InputEventBool : UnityEvent<bool> { } //will apper on the inspector 

public class Input_controller : MonoBehaviour
{
    public static Input_controller current;

    Controls controls;
    public MoveInputEvent moveInputEvent;
    public InputEventBool inputEventbool;

    public void Awake()
    {
        controls = new Controls();
        current = this;
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
        controls.Gameplay.Move.performed += OnMovePerformed;
        controls.Gameplay.Move.canceled += OnMovePerformed;
        controls.Gameplay.Interact.performed += InteractPreformed; // when E is pressed it down
    }

    private void InteractPreformed(InputAction.CallbackContext context) // when E is pressed it will call this function 
    {
        bool InteractInput = context.ReadValueAsButton(); // reads the input to see if E is pressed
        inputEventbool.Invoke(InteractInput); // used to respond to other functions trough unity insperctor (maybe)
        Debug.Log($"E pressed: { InteractInput}");
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveInputEvent.Invoke(moveInput.x, moveInput.y);
        Debug.Log($"move input: { moveInput}");
    }

    public event Action onDoorwayTriggerEnter;
    public void DoorwayTriggerEnter()
    {
        if(onDoorwayTriggerEnter != null)
        {
            onDoorwayTriggerEnter();
        }
    }

    public event Action onDoorwayTriggerExit;
    public void DoorwayTriggerExit()
    {
        if (onDoorwayTriggerExit != null)
        {
            onDoorwayTriggerExit();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

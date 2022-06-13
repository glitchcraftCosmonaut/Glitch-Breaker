using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Player Input")]
public class PlayerInput : ScriptableObject, InputActions.IGameplayActions
{
    public Vector2 MoveInput {get; private set;}
    public Vector3 MousePos {get; private set;}
    public Vector2 MouseScreenPos {get; private set;}
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }

    InputActions inputActions;



    #region UNITY MONOBEHAVIOR
    private void OnEnable()
    {
        inputActions = new InputActions();

        inputActions.Gameplay.SetCallbacks(this);
    //     inputActions.PauseMenu.SetCallbacks(this);
    //     int count = Enum.GetValues(typeof(CombatInputs)).Length;
    //     AttackInputs = new bool[count];
    }
    private void OnDisable()
    {
        DisableAllInput();

    }
#endregion
#region INPUT HANDLER

    void SwitchActionMap(InputActionMap actionMap, bool isUIInput)
    {
        inputActions.Disable();
        actionMap.Enable();
        Cursor.visible = false;


        // if(isUIInput)
        // {
        //     Cursor.visible = true;
        //     // Cursor.lockState = CursorLockMode.None;
        // }
        // else
        // {
        //     Cursor.visible = false;
        //     // Cursor.lockState = CursorLockMode.Locked;
        // }
    }
    public void SwitchToDynamicUpdateMode() => InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
    public void SwitchToFixedUpdateMode() => InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
    public void DisableAllInput() => inputActions.Disable();

    public void EnableGameplayInput() => SwitchActionMap(inputActions.Gameplay, false);
    // public void EnablePauseInput() => SwitchActionMap(inputActions.PauseMenu, true);
    
#endregion
   
    public void OnMousePosition(InputAction.CallbackContext context)
    {
        MousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        MouseScreenPos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
        NormInputX = Mathf.RoundToInt(MoveInput.x);
        NormInputY = Mathf.RoundToInt(MoveInput.y);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}

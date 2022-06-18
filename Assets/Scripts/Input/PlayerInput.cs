using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System;

// [CreateAssetMenu(menuName = "Player Input")]
public class PlayerInput : MonoBehaviour, InputActions.IGameplayActions
{
    private PlayerInput playerInput;
    private PlayerController player;
    public event UnityAction onAttack = delegate{};
    public event UnityAction onStopAttack = delegate{};
    public Vector2 MoveInput {get; private set;}
    public Vector3 MousePos {get; private set;}
    public Vector2 MouseScreenPos {get; private set;}
    public Vector2 RawAttackDirectionInput { get; private set; }
    public Vector2Int AttackDirectionInput { get; private set; }

    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool[] AttackInputs { get; private set; }
    public bool IsAttacking {get; private set;}

    InputActions inputActions;



    #region UNITY MONOBEHAVIOR
    private void OnEnable()
    {
        inputActions = new InputActions();

        inputActions.Gameplay.SetCallbacks(this);
        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];

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
        if(context.performed)
        {
            onAttack.Invoke();
        }
    }

    public void OnPrimaryAttack(InputAction.CallbackContext context)
    {
        // if(playerInput.currentControlScheme == "Keyboard")
        // RawAttackDirectionInput = Camera.main.ScreenToWorldPoint((Vector3)RawAttackDirectionInput) - player.transform.position;
        
        if(context.performed)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
            // IsAttacking = true;
            // onAttack.Invoke();
        }
        if(context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
            // IsAttacking = false;
            // onStopAttack.Invoke();
        }
    }

    public void OnAttackDirection(InputAction.CallbackContext context)
    {
        RawAttackDirectionInput = context.ReadValue<Vector2>();
        // RawAttackDirectionInput = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());;
        RawAttackDirectionInput = Camera.main.ScreenToWorldPoint((Vector3)RawAttackDirectionInput) - transform.position;
        AttackDirectionInput = Vector2Int.RoundToInt(RawAttackDirectionInput.normalized);
    }

    public enum CombatInputs
    {
        primary,
        secondary,
        shootFire
    }
}

// GENERATED AUTOMATICALLY FROM 'Assets/New Input System/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""dfa94449-51b0-4ae5-a3e6-f3c08e3f5623"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8a08321a-1f0c-4994-9c51-11309bffcdda"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""a32bc0af-55fb-4d42-93dc-5df5e9e4d6f3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryAttack"",
                    ""type"": ""Button"",
                    ""id"": ""6007ddf8-ef89-4103-b42a-8eba2986f184"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackDirection"",
                    ""type"": ""Value"",
                    ""id"": ""a6354c56-7340-487e-8f56-9556d5f6f9bf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""b15de68e-e4c8-4d94-85e9-1704a7856dbb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DashDirection"",
                    ""type"": ""Value"",
                    ""id"": ""e57664b8-48bd-41c0-a444-bd8810759d3d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""85e3167c-27d1-4713-9299-9460df700516"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Move"",
                    ""id"": ""9ab82712-9efe-4a29-8e70-1c224df7d382"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""18ce0674-d82f-404c-8c52-322ef7c01a23"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""78cf6b00-b04f-44fb-b235-882301891216"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d1aafca5-604e-4573-90be-606da597ab27"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3abd233d-7306-46d0-b48a-7796d00f1d6b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2eb55502-a104-4ab2-9e09-669eaf3282e0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""53540c34-2da8-4fd0-b030-4cde97ba7048"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d23ed97-efde-4b18-8663-2edfb58362ef"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""PrimaryAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e79038fe-8ac7-4e91-bda7-563496e928ff"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""AttackDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7134628b-3dcd-4ff9-8066-98d36077dcd5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f96e91dd-9571-450d-b0de-43e6fc710252"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""DashDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5dcb326-4792-4a0a-9d0a-c7b39db5defa"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1690068b-d713-4cde-9c6b-b300e3c613be"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseMenu"",
            ""id"": ""07bd5089-c0e5-4bf8-b89a-bbbd9607ffaa"",
            ""actions"": [
                {
                    ""name"": ""UnPause"",
                    ""type"": ""Button"",
                    ""id"": ""929ed58b-3334-4735-b256-0469bd60b55d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a71c3359-6931-479b-a2d3-87ab987d8b2c"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""UnPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db852896-8e07-4f07-9b34-82cfd60b122d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""UnPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameOverScreen"",
            ""id"": ""741818f3-ba52-42f9-a84c-181b62e0d3c9"",
            ""actions"": [
                {
                    ""name"": ""ConfirmGameOver"",
                    ""type"": ""Button"",
                    ""id"": ""e9aeaea7-c2e9-4dbb-9e42-982db8035e3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""efb93051-05b8-48d8-a34a-f437c39e45f0"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ConfirmGameOver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8796ac13-5007-4e6e-b396-1f43c1bd84d7"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ConfirmGameOver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": []
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_MousePosition = m_Gameplay.FindAction("MousePosition", throwIfNotFound: true);
        m_Gameplay_PrimaryAttack = m_Gameplay.FindAction("PrimaryAttack", throwIfNotFound: true);
        m_Gameplay_AttackDirection = m_Gameplay.FindAction("AttackDirection", throwIfNotFound: true);
        m_Gameplay_Dash = m_Gameplay.FindAction("Dash", throwIfNotFound: true);
        m_Gameplay_DashDirection = m_Gameplay.FindAction("DashDirection", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        // PauseMenu
        m_PauseMenu = asset.FindActionMap("PauseMenu", throwIfNotFound: true);
        m_PauseMenu_UnPause = m_PauseMenu.FindAction("UnPause", throwIfNotFound: true);
        // GameOverScreen
        m_GameOverScreen = asset.FindActionMap("GameOverScreen", throwIfNotFound: true);
        m_GameOverScreen_ConfirmGameOver = m_GameOverScreen.FindAction("ConfirmGameOver", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_MousePosition;
    private readonly InputAction m_Gameplay_PrimaryAttack;
    private readonly InputAction m_Gameplay_AttackDirection;
    private readonly InputAction m_Gameplay_Dash;
    private readonly InputAction m_Gameplay_DashDirection;
    private readonly InputAction m_Gameplay_Pause;
    public struct GameplayActions
    {
        private @InputActions m_Wrapper;
        public GameplayActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @MousePosition => m_Wrapper.m_Gameplay_MousePosition;
        public InputAction @PrimaryAttack => m_Wrapper.m_Gameplay_PrimaryAttack;
        public InputAction @AttackDirection => m_Wrapper.m_Gameplay_AttackDirection;
        public InputAction @Dash => m_Wrapper.m_Gameplay_Dash;
        public InputAction @DashDirection => m_Wrapper.m_Gameplay_DashDirection;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @MousePosition.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMousePosition;
                @PrimaryAttack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryAttack;
                @PrimaryAttack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryAttack;
                @PrimaryAttack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryAttack;
                @AttackDirection.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttackDirection;
                @AttackDirection.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttackDirection;
                @AttackDirection.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttackDirection;
                @Dash.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDash;
                @DashDirection.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashDirection;
                @DashDirection.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashDirection;
                @DashDirection.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDashDirection;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @PrimaryAttack.started += instance.OnPrimaryAttack;
                @PrimaryAttack.performed += instance.OnPrimaryAttack;
                @PrimaryAttack.canceled += instance.OnPrimaryAttack;
                @AttackDirection.started += instance.OnAttackDirection;
                @AttackDirection.performed += instance.OnAttackDirection;
                @AttackDirection.canceled += instance.OnAttackDirection;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @DashDirection.started += instance.OnDashDirection;
                @DashDirection.performed += instance.OnDashDirection;
                @DashDirection.canceled += instance.OnDashDirection;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // PauseMenu
    private readonly InputActionMap m_PauseMenu;
    private IPauseMenuActions m_PauseMenuActionsCallbackInterface;
    private readonly InputAction m_PauseMenu_UnPause;
    public struct PauseMenuActions
    {
        private @InputActions m_Wrapper;
        public PauseMenuActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @UnPause => m_Wrapper.m_PauseMenu_UnPause;
        public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuActions instance)
        {
            if (m_Wrapper.m_PauseMenuActionsCallbackInterface != null)
            {
                @UnPause.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnUnPause;
                @UnPause.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnUnPause;
                @UnPause.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnUnPause;
            }
            m_Wrapper.m_PauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UnPause.started += instance.OnUnPause;
                @UnPause.performed += instance.OnUnPause;
                @UnPause.canceled += instance.OnUnPause;
            }
        }
    }
    public PauseMenuActions @PauseMenu => new PauseMenuActions(this);

    // GameOverScreen
    private readonly InputActionMap m_GameOverScreen;
    private IGameOverScreenActions m_GameOverScreenActionsCallbackInterface;
    private readonly InputAction m_GameOverScreen_ConfirmGameOver;
    public struct GameOverScreenActions
    {
        private @InputActions m_Wrapper;
        public GameOverScreenActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ConfirmGameOver => m_Wrapper.m_GameOverScreen_ConfirmGameOver;
        public InputActionMap Get() { return m_Wrapper.m_GameOverScreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameOverScreenActions set) { return set.Get(); }
        public void SetCallbacks(IGameOverScreenActions instance)
        {
            if (m_Wrapper.m_GameOverScreenActionsCallbackInterface != null)
            {
                @ConfirmGameOver.started -= m_Wrapper.m_GameOverScreenActionsCallbackInterface.OnConfirmGameOver;
                @ConfirmGameOver.performed -= m_Wrapper.m_GameOverScreenActionsCallbackInterface.OnConfirmGameOver;
                @ConfirmGameOver.canceled -= m_Wrapper.m_GameOverScreenActionsCallbackInterface.OnConfirmGameOver;
            }
            m_Wrapper.m_GameOverScreenActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ConfirmGameOver.started += instance.OnConfirmGameOver;
                @ConfirmGameOver.performed += instance.OnConfirmGameOver;
                @ConfirmGameOver.canceled += instance.OnConfirmGameOver;
            }
        }
    }
    public GameOverScreenActions @GameOverScreen => new GameOverScreenActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnPrimaryAttack(InputAction.CallbackContext context);
        void OnAttackDirection(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnDashDirection(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IPauseMenuActions
    {
        void OnUnPause(InputAction.CallbackContext context);
    }
    public interface IGameOverScreenActions
    {
        void OnConfirmGameOver(InputAction.CallbackContext context);
    }
}

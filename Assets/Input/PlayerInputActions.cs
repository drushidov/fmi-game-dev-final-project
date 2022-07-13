// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""e02c2631-3831-45ac-9a22-246d37cf61ca"",
            ""actions"": [
                {
                    ""name"": ""ClickToMove"",
                    ""type"": ""Button"",
                    ""id"": ""b61d601f-7657-4b2a-93de-9e52a405cbe5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""5af5434c-0c8b-4788-9e1c-4e2d0e5f7ad6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseMenuTrigger"",
                    ""type"": ""Button"",
                    ""id"": ""bb9b2180-726f-4bf8-a383-b88ad38a2ced"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bc701e1e-984c-47ab-9ee1-1a882420c87a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickToMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""777d3598-23e6-457e-b54d-216a741ec0b8"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b5c37a5-40a1-4dc1-9d87-0a9b2e0f446f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PauseMenuTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_ClickToMove = m_Player.FindAction("ClickToMove", throwIfNotFound: true);
        m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
        m_Player_PauseMenuTrigger = m_Player.FindAction("PauseMenuTrigger", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_ClickToMove;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_PauseMenuTrigger;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ClickToMove => m_Wrapper.m_Player_ClickToMove;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @PauseMenuTrigger => m_Wrapper.m_Player_PauseMenuTrigger;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @ClickToMove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickToMove;
                @ClickToMove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickToMove;
                @ClickToMove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnClickToMove;
                @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                @PauseMenuTrigger.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenuTrigger;
                @PauseMenuTrigger.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenuTrigger;
                @PauseMenuTrigger.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPauseMenuTrigger;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ClickToMove.started += instance.OnClickToMove;
                @ClickToMove.performed += instance.OnClickToMove;
                @ClickToMove.canceled += instance.OnClickToMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @PauseMenuTrigger.started += instance.OnPauseMenuTrigger;
                @PauseMenuTrigger.performed += instance.OnPauseMenuTrigger;
                @PauseMenuTrigger.canceled += instance.OnPauseMenuTrigger;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnClickToMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnPauseMenuTrigger(InputAction.CallbackContext context);
    }
}

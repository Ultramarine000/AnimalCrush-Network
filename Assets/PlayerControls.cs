// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement-Cube"",
            ""id"": ""cdd46e03-bce4-4348-9924-026a07801175"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""6a11448a-fc85-4aed-ad3c-41288108c12d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""f38a38f2-282c-4d79-ba37-4c43cdf57b75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""697a32c1-c573-4365-aca6-cf11b68e037a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4c24cfea-1024-4cc7-aaa3-6cd1baa0e943"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""f89cf8d6-122a-4453-b92b-e817deeb5cad"",
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
                    ""id"": ""db74db97-b4b7-44a4-a3e9-f1e48b8c5372"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1186c14b-8659-4c91-93ff-b7924cc7e20d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b8b6a83d-5df3-4a0c-bbe7-212276ce8816"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0420748d-4f70-4d14-9bb6-92a1c65e96ae"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""967aebf4-1dac-42dd-be5d-65cb5a95b9ef"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3fbc9efe-d009-467b-a1dc-c2c171fd70e1"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""25d6e93e-af4d-4997-9d84-a22d6545cb12"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2978ce56-8f42-4fab-83d7-411f73abbfc8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement-Cube
        m_PlayerMovementCube = asset.FindActionMap("PlayerMovement-Cube", throwIfNotFound: true);
        m_PlayerMovementCube_Movement = m_PlayerMovementCube.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovementCube_Select = m_PlayerMovementCube.FindAction("Select", throwIfNotFound: true);
        m_PlayerMovementCube_Jump = m_PlayerMovementCube.FindAction("Jump", throwIfNotFound: true);
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

    // PlayerMovement-Cube
    private readonly InputActionMap m_PlayerMovementCube;
    private IPlayerMovementCubeActions m_PlayerMovementCubeActionsCallbackInterface;
    private readonly InputAction m_PlayerMovementCube_Movement;
    private readonly InputAction m_PlayerMovementCube_Select;
    private readonly InputAction m_PlayerMovementCube_Jump;
    public struct PlayerMovementCubeActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementCubeActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovementCube_Movement;
        public InputAction @Select => m_Wrapper.m_PlayerMovementCube_Select;
        public InputAction @Jump => m_Wrapper.m_PlayerMovementCube_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovementCube; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementCubeActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementCubeActions instance)
        {
            if (m_Wrapper.m_PlayerMovementCubeActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementCubeActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementCubeActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementCubeActionsCallbackInterface.OnMovement;
                @Select.started -= m_Wrapper.m_PlayerMovementCubeActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PlayerMovementCubeActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PlayerMovementCubeActionsCallbackInterface.OnSelect;
                @Jump.started -= m_Wrapper.m_PlayerMovementCubeActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMovementCubeActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMovementCubeActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerMovementCubeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerMovementCubeActions @PlayerMovementCube => new PlayerMovementCubeActions(this);
    public interface IPlayerMovementCubeActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}

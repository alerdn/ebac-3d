// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""b71ae0c6-6c97-4075-9c05-954285d9973e"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""74c498c6-7708-4a04-ac82-406bb2d8d9bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeGun"",
                    ""type"": ""Button"",
                    ""id"": ""f20ff8a1-6f53-43ca-84cf-1203a005b9a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectPrimaryGun"",
                    ""type"": ""Button"",
                    ""id"": ""b93e083e-c014-482e-8280-4c16cdb0c47b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectSecondaryGun"",
                    ""type"": ""Button"",
                    ""id"": ""b5cd6ccf-5908-4a99-93c1-7bd058a0cd1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""0974dc0a-24e7-4c5a-abf8-6bd251b8aa2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ef4db03b-42a4-4265-88a7-a5c8e6d8be21"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/button8"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""013564d9-2b6c-477d-ae8c-26ac74934a24"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb195475-f9f4-469c-9f70-79c2e2036c28"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2353b4c9-f7b3-424c-9b4d-43cfe6dadf50"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1f06d50-69c1-474b-a453-b60ac600fb2b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectPrimaryGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e32909b-f026-4b39-8c5b-615234fb21ad"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSecondaryGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfc88431-7dd4-4e7b-93ed-cde146267993"",
                    ""path"": ""<HID::Sony Interactive Entertainment DualSense Wireless Controller>/button6"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6194c25-3ba6-4511-becc-bd8076e3775e"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_ChangeGun = m_Gameplay.FindAction("ChangeGun", throwIfNotFound: true);
        m_Gameplay_SelectPrimaryGun = m_Gameplay.FindAction("SelectPrimaryGun", throwIfNotFound: true);
        m_Gameplay_SelectSecondaryGun = m_Gameplay.FindAction("SelectSecondaryGun", throwIfNotFound: true);
        m_Gameplay_Run = m_Gameplay.FindAction("Run", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_ChangeGun;
    private readonly InputAction m_Gameplay_SelectPrimaryGun;
    private readonly InputAction m_Gameplay_SelectSecondaryGun;
    private readonly InputAction m_Gameplay_Run;
    public struct GameplayActions
    {
        private @Inputs m_Wrapper;
        public GameplayActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @ChangeGun => m_Wrapper.m_Gameplay_ChangeGun;
        public InputAction @SelectPrimaryGun => m_Wrapper.m_Gameplay_SelectPrimaryGun;
        public InputAction @SelectSecondaryGun => m_Wrapper.m_Gameplay_SelectSecondaryGun;
        public InputAction @Run => m_Wrapper.m_Gameplay_Run;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @ChangeGun.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeGun;
                @ChangeGun.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeGun;
                @ChangeGun.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeGun;
                @SelectPrimaryGun.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectPrimaryGun;
                @SelectPrimaryGun.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectPrimaryGun;
                @SelectPrimaryGun.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectPrimaryGun;
                @SelectSecondaryGun.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectSecondaryGun;
                @SelectSecondaryGun.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectSecondaryGun;
                @SelectSecondaryGun.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSelectSecondaryGun;
                @Run.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRun;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @ChangeGun.started += instance.OnChangeGun;
                @ChangeGun.performed += instance.OnChangeGun;
                @ChangeGun.canceled += instance.OnChangeGun;
                @SelectPrimaryGun.started += instance.OnSelectPrimaryGun;
                @SelectPrimaryGun.performed += instance.OnSelectPrimaryGun;
                @SelectPrimaryGun.canceled += instance.OnSelectPrimaryGun;
                @SelectSecondaryGun.started += instance.OnSelectSecondaryGun;
                @SelectSecondaryGun.performed += instance.OnSelectSecondaryGun;
                @SelectSecondaryGun.canceled += instance.OnSelectSecondaryGun;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnChangeGun(InputAction.CallbackContext context);
        void OnSelectPrimaryGun(InputAction.CallbackContext context);
        void OnSelectSecondaryGun(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
}

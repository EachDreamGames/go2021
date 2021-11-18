// GENERATED AUTOMATICALLY FROM 'Assets/TheGame/Input/InputControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Ladybug"",
            ""id"": ""8fe22cdd-74ed-4333-b93a-f857099da4d6"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""eda626ee-0a15-4b2e-8946-9ccb0db45926"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""7295aadc-5c46-42e5-a492-7d2b075f3a30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IsRunning"",
                    ""type"": ""Button"",
                    ""id"": ""2dba5a3e-6e15-46c7-bf7e-6995b9c25006"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WalkSpeedMultiplier"",
                    ""type"": ""Value"",
                    ""id"": ""6bb2fc81-b933-4f82-bbf3-56d86e0d91d9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""1866d14e-9499-4c42-adc7-d3ead858784b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Kick"",
                    ""type"": ""Button"",
                    ""id"": ""4f5f7896-7f88-4f60-a2fd-9844304886b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spit"",
                    ""type"": ""Button"",
                    ""id"": ""b073a90f-db4f-4a4f-8fc7-431f61cbb118"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""0c591a49-b297-4e98-b58d-416faf890493"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseAim"",
                    ""type"": ""Value"",
                    ""id"": ""9fb9c290-be47-4e12-b35b-6d51d9a19797"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""863c8756-0cfe-440e-926a-f0387280985e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d5de176a-92da-4e9a-8a29-2a99dd2ce0cf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1e287934-a5da-49c3-b486-9c7770b91410"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""acd8ef2d-f489-4217-bd85-0c8fb3dbc174"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5deff304-2375-4c86-8c85-6125b13868e5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b0d7292f-5129-4588-bb8f-bd7d10c8b40e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""4b9e4558-1dfd-4973-b1d9-1d8d638900ab"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""25272ef9-98e7-4898-abb5-542cdaaf8096"",
                    ""path"": ""<XInputController>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""22761ca2-294a-4028-bc11-9615cbdae658"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""855db161-139a-4258-8f47-ad1dc6a46112"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8eb589fe-533a-4a45-a57d-9661a54f3d32"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ea0eb2ba-54cd-4ac5-b132-634534880c9d"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bb271269-f1e5-4d49-8567-5303feec0c3f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e32ab10a-9ea7-48ad-bb89-17aad0b9730c"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7f2bd7c-5731-4650-8a5e-e53bc253f728"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IsRunning"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96300e32-4f7f-4920-bd19-453793c1ac22"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkSpeedMultiplier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b9aceb1-03a4-477a-8f5c-2dd60ef0066a"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WalkSpeedMultiplier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""175322ca-b2c0-40e7-bcf3-dac800ff2c5e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dec14ebe-a396-407a-876c-9ac386ad6b90"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""442d4c25-b820-4af1-b465-acc917e139e1"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5883f713-4556-49a4-bb66-10ee69ac7595"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07cace07-033b-4779-999f-41c8e16ed8df"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82cff631-e26e-4202-9252-7bf941256035"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ac71efd-404e-4384-b042-4a2f0c44b9a7"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ee7e193-4295-4e7e-b71b-a7b8ab609278"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameController"",
            ""id"": ""e41334ea-6c93-4ede-b4c5-6b43235a85da"",
            ""actions"": [
                {
                    ""name"": ""AnyKey"",
                    ""type"": ""Button"",
                    ""id"": ""e4c4aa4d-3964-4719-bfae-46f48160b4e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Close"",
                    ""type"": ""Button"",
                    ""id"": ""b3b3914a-c0c9-4d82-b602-2e01bf923d34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""03be062b-0153-424f-a753-c6cb796ac849"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0354f9ca-32e6-4bb3-9373-ccc81227f89b"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bd9a025-5f86-4a4f-9bd7-f3ee62e50147"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""717d9212-0199-4739-878e-bf8c1d7fb8bf"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""125ec8d5-0e57-47fa-b4b9-963fdee131c4"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ladybug
        m_Ladybug = asset.FindActionMap("Ladybug", throwIfNotFound: true);
        m_Ladybug_Walk = m_Ladybug.FindAction("Walk", throwIfNotFound: true);
        m_Ladybug_Jump = m_Ladybug.FindAction("Jump", throwIfNotFound: true);
        m_Ladybug_IsRunning = m_Ladybug.FindAction("IsRunning", throwIfNotFound: true);
        m_Ladybug_WalkSpeedMultiplier = m_Ladybug.FindAction("WalkSpeedMultiplier", throwIfNotFound: true);
        m_Ladybug_Interact = m_Ladybug.FindAction("Interact", throwIfNotFound: true);
        m_Ladybug_Kick = m_Ladybug.FindAction("Kick", throwIfNotFound: true);
        m_Ladybug_Spit = m_Ladybug.FindAction("Spit", throwIfNotFound: true);
        m_Ladybug_Aim = m_Ladybug.FindAction("Aim", throwIfNotFound: true);
        m_Ladybug_MouseAim = m_Ladybug.FindAction("MouseAim", throwIfNotFound: true);
        // GameController
        m_GameController = asset.FindActionMap("GameController", throwIfNotFound: true);
        m_GameController_AnyKey = m_GameController.FindAction("AnyKey", throwIfNotFound: true);
        m_GameController_Close = m_GameController.FindAction("Close", throwIfNotFound: true);
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

    // Ladybug
    private readonly InputActionMap m_Ladybug;
    private ILadybugActions m_LadybugActionsCallbackInterface;
    private readonly InputAction m_Ladybug_Walk;
    private readonly InputAction m_Ladybug_Jump;
    private readonly InputAction m_Ladybug_IsRunning;
    private readonly InputAction m_Ladybug_WalkSpeedMultiplier;
    private readonly InputAction m_Ladybug_Interact;
    private readonly InputAction m_Ladybug_Kick;
    private readonly InputAction m_Ladybug_Spit;
    private readonly InputAction m_Ladybug_Aim;
    private readonly InputAction m_Ladybug_MouseAim;
    public struct LadybugActions
    {
        private @InputControls m_Wrapper;
        public LadybugActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Ladybug_Walk;
        public InputAction @Jump => m_Wrapper.m_Ladybug_Jump;
        public InputAction @IsRunning => m_Wrapper.m_Ladybug_IsRunning;
        public InputAction @WalkSpeedMultiplier => m_Wrapper.m_Ladybug_WalkSpeedMultiplier;
        public InputAction @Interact => m_Wrapper.m_Ladybug_Interact;
        public InputAction @Kick => m_Wrapper.m_Ladybug_Kick;
        public InputAction @Spit => m_Wrapper.m_Ladybug_Spit;
        public InputAction @Aim => m_Wrapper.m_Ladybug_Aim;
        public InputAction @MouseAim => m_Wrapper.m_Ladybug_MouseAim;
        public InputActionMap Get() { return m_Wrapper.m_Ladybug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LadybugActions set) { return set.Get(); }
        public void SetCallbacks(ILadybugActions instance)
        {
            if (m_Wrapper.m_LadybugActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_LadybugActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_LadybugActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_LadybugActionsCallbackInterface.OnWalk;
                @Jump.started -= m_Wrapper.m_LadybugActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LadybugActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LadybugActionsCallbackInterface.OnJump;
                @IsRunning.started -= m_Wrapper.m_LadybugActionsCallbackInterface.OnIsRunning;
                @IsRunning.performed -= m_Wrapper.m_LadybugActionsCallbackInterface.OnIsRunning;
                @IsRunning.canceled -= m_Wrapper.m_LadybugActionsCallbackInterface.OnIsRunning;
                @WalkSpeedMultiplier.started -= m_Wrapper.m_LadybugActionsCallbackInterface.OnWalkSpeedMultiplier;
                @WalkSpeedMultiplier.performed -= m_Wrapper.m_LadybugActionsCallbackInterface.OnWalkSpeedMultiplier;
                @WalkSpeedMultiplier.canceled -= m_Wrapper.m_LadybugActionsCallbackInterface.OnWalkSpeedMultiplier;
                @Interact.started -= m_Wrapper.m_LadybugActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_LadybugActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_LadybugActionsCallbackInterface.OnInteract;
                @Kick.started -= m_Wrapper.m_LadybugActionsCallbackInterface.OnKick;
                @Kick.performed -= m_Wrapper.m_LadybugActionsCallbackInterface.OnKick;
                @Kick.canceled -= m_Wrapper.m_LadybugActionsCallbackInterface.OnKick;
                @Spit.started -= m_Wrapper.m_LadybugActionsCallbackInterface.OnSpit;
                @Spit.performed -= m_Wrapper.m_LadybugActionsCallbackInterface.OnSpit;
                @Spit.canceled -= m_Wrapper.m_LadybugActionsCallbackInterface.OnSpit;
                @Aim.started -= m_Wrapper.m_LadybugActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_LadybugActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_LadybugActionsCallbackInterface.OnAim;
                @MouseAim.started -= m_Wrapper.m_LadybugActionsCallbackInterface.OnMouseAim;
                @MouseAim.performed -= m_Wrapper.m_LadybugActionsCallbackInterface.OnMouseAim;
                @MouseAim.canceled -= m_Wrapper.m_LadybugActionsCallbackInterface.OnMouseAim;
            }
            m_Wrapper.m_LadybugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @IsRunning.started += instance.OnIsRunning;
                @IsRunning.performed += instance.OnIsRunning;
                @IsRunning.canceled += instance.OnIsRunning;
                @WalkSpeedMultiplier.started += instance.OnWalkSpeedMultiplier;
                @WalkSpeedMultiplier.performed += instance.OnWalkSpeedMultiplier;
                @WalkSpeedMultiplier.canceled += instance.OnWalkSpeedMultiplier;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Kick.started += instance.OnKick;
                @Kick.performed += instance.OnKick;
                @Kick.canceled += instance.OnKick;
                @Spit.started += instance.OnSpit;
                @Spit.performed += instance.OnSpit;
                @Spit.canceled += instance.OnSpit;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @MouseAim.started += instance.OnMouseAim;
                @MouseAim.performed += instance.OnMouseAim;
                @MouseAim.canceled += instance.OnMouseAim;
            }
        }
    }
    public LadybugActions @Ladybug => new LadybugActions(this);

    // GameController
    private readonly InputActionMap m_GameController;
    private IGameControllerActions m_GameControllerActionsCallbackInterface;
    private readonly InputAction m_GameController_AnyKey;
    private readonly InputAction m_GameController_Close;
    public struct GameControllerActions
    {
        private @InputControls m_Wrapper;
        public GameControllerActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @AnyKey => m_Wrapper.m_GameController_AnyKey;
        public InputAction @Close => m_Wrapper.m_GameController_Close;
        public InputActionMap Get() { return m_Wrapper.m_GameController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControllerActions set) { return set.Get(); }
        public void SetCallbacks(IGameControllerActions instance)
        {
            if (m_Wrapper.m_GameControllerActionsCallbackInterface != null)
            {
                @AnyKey.started -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnAnyKey;
                @AnyKey.performed -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnAnyKey;
                @AnyKey.canceled -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnAnyKey;
                @Close.started -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnClose;
                @Close.performed -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnClose;
                @Close.canceled -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnClose;
            }
            m_Wrapper.m_GameControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AnyKey.started += instance.OnAnyKey;
                @AnyKey.performed += instance.OnAnyKey;
                @AnyKey.canceled += instance.OnAnyKey;
                @Close.started += instance.OnClose;
                @Close.performed += instance.OnClose;
                @Close.canceled += instance.OnClose;
            }
        }
    }
    public GameControllerActions @GameController => new GameControllerActions(this);
    public interface ILadybugActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnIsRunning(InputAction.CallbackContext context);
        void OnWalkSpeedMultiplier(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
        void OnSpit(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnMouseAim(InputAction.CallbackContext context);
    }
    public interface IGameControllerActions
    {
        void OnAnyKey(InputAction.CallbackContext context);
        void OnClose(InputAction.CallbackContext context);
    }
}

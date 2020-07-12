// GENERATED AUTOMATICALLY FROM 'Assets/Equilibrium/Inputs/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Equilibrium
{
    public class @PlayerInputs : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""PlayerKeys"",
            ""id"": ""96d0a0dc-0037-41d5-8a18-4049e8e84019"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""13b084b6-e135-4064-ba36-868defbaf45a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""b11b2bed-7245-470a-8dee-100a4b0a341d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""a6d41fe4-59d4-47f6-99c5-94bcc715a3f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MoveWASD"",
                    ""id"": ""7d8dd882-32ce-4f1b-abac-2199a70075ff"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""50e34e2d-64c0-40a2-ab0b-8a9445b75c66"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4922ea53-51a7-4539-a13d-e6b48b91309f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""47cb3875-7909-42d4-b6d4-2b2a4be465bc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4905ecae-5e8f-4a2d-8090-929d294bd190"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""MoveArrows"",
                    ""id"": ""75f079eb-ff4c-4844-adc2-b639f29a6410"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""45919ac7-1adf-4b89-9429-9dcc465f7c5e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d327d2d0-f36d-4889-84c8-aa33960ad0c9"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""850ca68f-f617-4886-be0f-7be5c9b05b6a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5269572f-d6ba-4bec-81ec-3e92c2776d24"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ac619212-60a8-473b-bd5f-a6ad5a30c8d9"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44454707-997e-4c89-ab49-99b6f330c840"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerKeys
            m_PlayerKeys = asset.FindActionMap("PlayerKeys", throwIfNotFound: true);
            m_PlayerKeys_Move = m_PlayerKeys.FindAction("Move", throwIfNotFound: true);
            m_PlayerKeys_Roll = m_PlayerKeys.FindAction("Roll", throwIfNotFound: true);
            m_PlayerKeys_Attack = m_PlayerKeys.FindAction("Attack", throwIfNotFound: true);
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

        // PlayerKeys
        private readonly InputActionMap m_PlayerKeys;
        private IPlayerKeysActions m_PlayerKeysActionsCallbackInterface;
        private readonly InputAction m_PlayerKeys_Move;
        private readonly InputAction m_PlayerKeys_Roll;
        private readonly InputAction m_PlayerKeys_Attack;
        public struct PlayerKeysActions
        {
            private @PlayerInputs m_Wrapper;
            public PlayerKeysActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_PlayerKeys_Move;
            public InputAction @Roll => m_Wrapper.m_PlayerKeys_Roll;
            public InputAction @Attack => m_Wrapper.m_PlayerKeys_Attack;
            public InputActionMap Get() { return m_Wrapper.m_PlayerKeys; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerKeysActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerKeysActions instance)
            {
                if (m_Wrapper.m_PlayerKeysActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PlayerKeysActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerKeysActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerKeysActionsCallbackInterface.OnMove;
                    @Roll.started -= m_Wrapper.m_PlayerKeysActionsCallbackInterface.OnRoll;
                    @Roll.performed -= m_Wrapper.m_PlayerKeysActionsCallbackInterface.OnRoll;
                    @Roll.canceled -= m_Wrapper.m_PlayerKeysActionsCallbackInterface.OnRoll;
                    @Attack.started -= m_Wrapper.m_PlayerKeysActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_PlayerKeysActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_PlayerKeysActionsCallbackInterface.OnAttack;
                }
                m_Wrapper.m_PlayerKeysActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Roll.started += instance.OnRoll;
                    @Roll.performed += instance.OnRoll;
                    @Roll.canceled += instance.OnRoll;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                }
            }
        }
        public PlayerKeysActions @PlayerKeys => new PlayerKeysActions(this);
        public interface IPlayerKeysActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnRoll(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/ExplosiveLLC/Warrior/Inputs/WarriorInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace WarriorAnims
{
    public partial class @WarriorInputs: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @WarriorInputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""WarriorInputActions"",
    ""maps"": [
        {
            ""name"": ""Warrior"",
            ""id"": ""0a7f8955-1d90-4957-9188-c7760be557a9"",
            ""actions"": [
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Button"",
                    ""id"": ""4c7c500f-1efc-4d60-9f71-7792f9715889"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""7b7e6ac2-6a6b-4ace-a751-fcc372080040"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Death"",
                    ""type"": ""Button"",
                    ""id"": ""7dca37f5-81fc-4476-ab77-6e104272f128"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LightHit"",
                    ""type"": ""Button"",
                    ""id"": ""99302c12-4535-4563-ab24-93c601443533"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Value"",
                    ""id"": ""d9b4b70b-da1e-4b89-b1c9-8b74c58b5a46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Target"",
                    ""type"": ""Button"",
                    ""id"": ""7bc350e1-c521-4c11-9f85-1dc6c21f04df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""f518dd7e-9c49-4df0-b6de-91e2bb07eb76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttackMove"",
                    ""type"": ""Button"",
                    ""id"": ""58c72571-47ba-4a46-8917-0441155c80d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttackRanged"",
                    ""type"": ""Button"",
                    ""id"": ""ab8c56c2-daae-4fc5-82c4-a84719da2729"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""AttackSpecial"",
                    ""type"": ""Button"",
                    ""id"": ""a39ce9dc-edea-4d3f-a086-7d2b3b794ab0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Face"",
                    ""type"": ""Button"",
                    ""id"": ""371f1467-db95-4114-8932-f864ec31ad17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a61f6ad4-6c22-47a3-afcf-49c0c913c928"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Facing"",
                    ""type"": ""Value"",
                    ""id"": ""cab2ed49-3fd8-44b0-a2f9-a32382df7ff7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""46762193-a26f-4506-b421-2c57e9a52a30"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7882b190-b27e-48b0-892f-8462153056e3"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(min=0.125,max=0.925)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""9354bc7e-fb47-467f-8f14-24bddd17c717"",
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
                    ""id"": ""8d43fcf9-680b-4fe3-90f3-849eaad0150b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""61a9c244-6c86-46a2-bd82-e0094bd76b41"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""02dfb85b-6299-46bc-8ae0-fa9336eb5a58"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""395ea063-cbd0-448c-a1fb-8a2f61331ab1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1dde3f97-fe44-477f-8566-2af9067c3aa9"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false),StickDeadzone(min=0.125,max=0.925)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Facing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5127668-7790-4441-a492-dc0b43a7d732"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c07c290f-895e-49d3-b642-0dfcb5d2e3da"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51961bc6-0819-4027-a717-749f714390b3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Face"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d5051b3-1c3e-4a43-974c-16491e216b1b"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AttackMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f599944-6d94-47bc-8d27-c67675d37692"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d007959-ba17-4ab5-9c64-6379ace06e0e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0960ff8-4c57-498b-b815-904d7a23631a"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LightHit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13d06e79-c037-425b-878a-43c2beca2894"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Death"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a64b1138-8169-472d-8e36-25c1123b63af"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad;Mouse and Keyboard"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""d4bea8e5-0a5d-400d-94e2-e243974cd7c9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b0744ef1-2fbb-4b29-9492-6c09d2c5b564"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard;Gamepad"",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5e7c3d84-1d4b-4f40-8969-5601e9af5575"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard;Gamepad"",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""319e0b4b-8807-4355-a318-b0d07ad50c87"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard;Gamepad"",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""df008ec6-43de-4953-98c5-513916a1ecb5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard;Gamepad"",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d284cc0a-5faf-4c87-ad80-03265e6e0528"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AttackRanged"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdeb6fd5-188b-4fa7-8b17-7f509fd7e947"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AttackSpecial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72ff5327-52dc-4168-b18b-0c1fbda828c5"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69de6706-3b4e-4c7b-bd6f-162901094282"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": []
        },
        {
            ""name"": ""Mouse and Keyboard"",
            ""bindingGroup"": ""Mouse and Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Warrior
            m_Warrior = asset.FindActionMap("Warrior", throwIfNotFound: true);
            m_Warrior_Aiming = m_Warrior.FindAction("Aiming", throwIfNotFound: true);
            m_Warrior_Roll = m_Warrior.FindAction("Roll", throwIfNotFound: true);
            m_Warrior_Death = m_Warrior.FindAction("Death", throwIfNotFound: true);
            m_Warrior_LightHit = m_Warrior.FindAction("LightHit", throwIfNotFound: true);
            m_Warrior_Block = m_Warrior.FindAction("Block", throwIfNotFound: true);
            m_Warrior_Target = m_Warrior.FindAction("Target", throwIfNotFound: true);
            m_Warrior_Attack = m_Warrior.FindAction("Attack", throwIfNotFound: true);
            m_Warrior_AttackMove = m_Warrior.FindAction("AttackMove", throwIfNotFound: true);
            m_Warrior_AttackRanged = m_Warrior.FindAction("AttackRanged", throwIfNotFound: true);
            m_Warrior_AttackSpecial = m_Warrior.FindAction("AttackSpecial", throwIfNotFound: true);
            m_Warrior_Face = m_Warrior.FindAction("Face", throwIfNotFound: true);
            m_Warrior_Jump = m_Warrior.FindAction("Jump", throwIfNotFound: true);
            m_Warrior_Facing = m_Warrior.FindAction("Facing", throwIfNotFound: true);
            m_Warrior_Move = m_Warrior.FindAction("Move", throwIfNotFound: true);
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Warrior
        private readonly InputActionMap m_Warrior;
        private List<IWarriorActions> m_WarriorActionsCallbackInterfaces = new List<IWarriorActions>();
        private readonly InputAction m_Warrior_Aiming;
        private readonly InputAction m_Warrior_Roll;
        private readonly InputAction m_Warrior_Death;
        private readonly InputAction m_Warrior_LightHit;
        private readonly InputAction m_Warrior_Block;
        private readonly InputAction m_Warrior_Target;
        private readonly InputAction m_Warrior_Attack;
        private readonly InputAction m_Warrior_AttackMove;
        private readonly InputAction m_Warrior_AttackRanged;
        private readonly InputAction m_Warrior_AttackSpecial;
        private readonly InputAction m_Warrior_Face;
        private readonly InputAction m_Warrior_Jump;
        private readonly InputAction m_Warrior_Facing;
        private readonly InputAction m_Warrior_Move;
        public struct WarriorActions
        {
            private @WarriorInputs m_Wrapper;
            public WarriorActions(@WarriorInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Aiming => m_Wrapper.m_Warrior_Aiming;
            public InputAction @Roll => m_Wrapper.m_Warrior_Roll;
            public InputAction @Death => m_Wrapper.m_Warrior_Death;
            public InputAction @LightHit => m_Wrapper.m_Warrior_LightHit;
            public InputAction @Block => m_Wrapper.m_Warrior_Block;
            public InputAction @Target => m_Wrapper.m_Warrior_Target;
            public InputAction @Attack => m_Wrapper.m_Warrior_Attack;
            public InputAction @AttackMove => m_Wrapper.m_Warrior_AttackMove;
            public InputAction @AttackRanged => m_Wrapper.m_Warrior_AttackRanged;
            public InputAction @AttackSpecial => m_Wrapper.m_Warrior_AttackSpecial;
            public InputAction @Face => m_Wrapper.m_Warrior_Face;
            public InputAction @Jump => m_Wrapper.m_Warrior_Jump;
            public InputAction @Facing => m_Wrapper.m_Warrior_Facing;
            public InputAction @Move => m_Wrapper.m_Warrior_Move;
            public InputActionMap Get() { return m_Wrapper.m_Warrior; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(WarriorActions set) { return set.Get(); }
            public void AddCallbacks(IWarriorActions instance)
            {
                if (instance == null || m_Wrapper.m_WarriorActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_WarriorActionsCallbackInterfaces.Add(instance);
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Death.started += instance.OnDeath;
                @Death.performed += instance.OnDeath;
                @Death.canceled += instance.OnDeath;
                @LightHit.started += instance.OnLightHit;
                @LightHit.performed += instance.OnLightHit;
                @LightHit.canceled += instance.OnLightHit;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
                @Target.started += instance.OnTarget;
                @Target.performed += instance.OnTarget;
                @Target.canceled += instance.OnTarget;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @AttackMove.started += instance.OnAttackMove;
                @AttackMove.performed += instance.OnAttackMove;
                @AttackMove.canceled += instance.OnAttackMove;
                @AttackRanged.started += instance.OnAttackRanged;
                @AttackRanged.performed += instance.OnAttackRanged;
                @AttackRanged.canceled += instance.OnAttackRanged;
                @AttackSpecial.started += instance.OnAttackSpecial;
                @AttackSpecial.performed += instance.OnAttackSpecial;
                @AttackSpecial.canceled += instance.OnAttackSpecial;
                @Face.started += instance.OnFace;
                @Face.performed += instance.OnFace;
                @Face.canceled += instance.OnFace;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Facing.started += instance.OnFacing;
                @Facing.performed += instance.OnFacing;
                @Facing.canceled += instance.OnFacing;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }

            private void UnregisterCallbacks(IWarriorActions instance)
            {
                @Aiming.started -= instance.OnAiming;
                @Aiming.performed -= instance.OnAiming;
                @Aiming.canceled -= instance.OnAiming;
                @Roll.started -= instance.OnRoll;
                @Roll.performed -= instance.OnRoll;
                @Roll.canceled -= instance.OnRoll;
                @Death.started -= instance.OnDeath;
                @Death.performed -= instance.OnDeath;
                @Death.canceled -= instance.OnDeath;
                @LightHit.started -= instance.OnLightHit;
                @LightHit.performed -= instance.OnLightHit;
                @LightHit.canceled -= instance.OnLightHit;
                @Block.started -= instance.OnBlock;
                @Block.performed -= instance.OnBlock;
                @Block.canceled -= instance.OnBlock;
                @Target.started -= instance.OnTarget;
                @Target.performed -= instance.OnTarget;
                @Target.canceled -= instance.OnTarget;
                @Attack.started -= instance.OnAttack;
                @Attack.performed -= instance.OnAttack;
                @Attack.canceled -= instance.OnAttack;
                @AttackMove.started -= instance.OnAttackMove;
                @AttackMove.performed -= instance.OnAttackMove;
                @AttackMove.canceled -= instance.OnAttackMove;
                @AttackRanged.started -= instance.OnAttackRanged;
                @AttackRanged.performed -= instance.OnAttackRanged;
                @AttackRanged.canceled -= instance.OnAttackRanged;
                @AttackSpecial.started -= instance.OnAttackSpecial;
                @AttackSpecial.performed -= instance.OnAttackSpecial;
                @AttackSpecial.canceled -= instance.OnAttackSpecial;
                @Face.started -= instance.OnFace;
                @Face.performed -= instance.OnFace;
                @Face.canceled -= instance.OnFace;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Facing.started -= instance.OnFacing;
                @Facing.performed -= instance.OnFacing;
                @Facing.canceled -= instance.OnFacing;
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
            }

            public void RemoveCallbacks(IWarriorActions instance)
            {
                if (m_Wrapper.m_WarriorActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IWarriorActions instance)
            {
                foreach (var item in m_Wrapper.m_WarriorActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_WarriorActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public WarriorActions @Warrior => new WarriorActions(this);
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        private int m_MouseandKeyboardSchemeIndex = -1;
        public InputControlScheme MouseandKeyboardScheme
        {
            get
            {
                if (m_MouseandKeyboardSchemeIndex == -1) m_MouseandKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and Keyboard");
                return asset.controlSchemes[m_MouseandKeyboardSchemeIndex];
            }
        }
        public interface IWarriorActions
        {
            void OnAiming(InputAction.CallbackContext context);
            void OnRoll(InputAction.CallbackContext context);
            void OnDeath(InputAction.CallbackContext context);
            void OnLightHit(InputAction.CallbackContext context);
            void OnBlock(InputAction.CallbackContext context);
            void OnTarget(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnAttackMove(InputAction.CallbackContext context);
            void OnAttackRanged(InputAction.CallbackContext context);
            void OnAttackSpecial(InputAction.CallbackContext context);
            void OnFace(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnFacing(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/GameAssets/Scripts/Input/MovementActions.inputactions
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

public partial class @MovementActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MovementActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MovementActions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""65086328-0fba-4ced-a9ad-281a5db3ede1"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9da37897-9fab-42a1-b5d8-6fefc98ba3e4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""317b44b6-69a2-4f16-8459-7ff071438999"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8725746c-06a8-441d-bf9c-5007f0e83960"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""7f7ed9af-28be-4f44-aed9-9d05eb3bb529"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""74f5759e-e5ac-4210-8db2-9d512e6f664d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RB"",
                    ""type"": ""Button"",
                    ""id"": ""356db770-d051-4648-bb1c-5fa3cdd9120a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RT"",
                    ""type"": ""Button"",
                    ""id"": ""692b300b-efd0-4195-ae45-d98d43d8c3c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DPadUp"",
                    ""type"": ""Button"",
                    ""id"": ""e2a7612e-0c40-4dd3-9669-e2728ebf0946"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DPadDown"",
                    ""type"": ""Button"",
                    ""id"": ""a30f397b-954c-457d-90b7-3cbb78ea0677"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DPadLeft"",
                    ""type"": ""Button"",
                    ""id"": ""8ec88015-4020-48c1-b73e-043720c78ff7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DPadRight"",
                    ""type"": ""Button"",
                    ""id"": ""a74845f4-bb86-4bb9-9201-2f6254ca5822"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""87b7b78d-7dac-4b9d-a0d8-e69332ccb4cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""20b2b8cd-524d-41e9-ac43-7dacab5d8471"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""25e842cd-3929-4cfb-9dc3-05a92dc2d89f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b354c5de-ab60-41fa-9047-b66c6303a713"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fed7eea-379d-41fe-a74f-bb1d008d911c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e433ff48-5b56-434a-9d5f-aac3ec1979d2"",
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
                    ""id"": ""b364e981-6687-4e5b-ae41-baa2ed80f202"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3e07b6c1-3629-4a07-88a3-407227a8ea2a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e09524dc-d1a6-4ea6-bd02-af6506fb40fc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5bec65bd-978d-4bd3-890e-bae44bc0dbb1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""7c117083-350f-4721-b12f-ed62b6c13cf4"",
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
                    ""id"": ""321d8fc9-2493-4122-8014-d2bad72794c0"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c46d6f11-ce62-4f21-831f-90975e613a80"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b6883329-682e-4c1b-a662-981de0939ed1"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""705dfbe5-4720-48ab-bcdd-98d17ed6d304"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Dpad"",
                    ""id"": ""1b32a826-52b6-40eb-8682-32c2912b7781"",
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
                    ""id"": ""60b73453-66f8-47f3-a501-b8415d67924f"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8fc02557-d0f9-41b5-a530-3dcfe786592f"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b127a8f5-e19c-46d1-9831-82ad9d467204"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0e0ba307-55a4-4dab-a43c-1e5a6368849a"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4bde1122-00da-49fc-b7d5-1e79d2f32f5b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.01)"",
                    ""groups"": ""Mouse"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""RightStick"",
                    ""id"": ""878fc35f-c729-4e2e-ab35-a0ba43b14f81"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""31da5273-203a-460d-9bc9-81d153da487e"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f1c0c343-2ceb-487e-b394-98d57177a11d"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f6e19b03-9c19-473f-b29d-3352d01bc332"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5f5b9b8a-3c6c-4365-a65e-af9a2e91f2a2"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7127d6f5-dd11-482b-991f-89a44f33f107"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21785121-b03a-4601-8950-4197d77f8d99"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0eb7b1d4-7193-4ea0-a009-73b6d6924991"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80b03b73-ee97-46c3-a00a-598aa4029cbb"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7c2ed45-0b80-4da9-8dd6-4ee81d16da38"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aae6f1a4-17e8-4e6d-b9fa-49bf044342b6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfd84691-9b1b-4e23-ba41-887d2ddfc3fa"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ce31572-61a0-4635-a7de-f34a80c82684"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6050a040-c9cd-4795-8e27-99fb9d203e01"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d257e8c-b53f-4802-8aa4-88c0352241b3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPadRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8af347c9-d178-4e94-883e-653249db1bcd"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d92d8550-25d4-449a-a154-872f08751a3b"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e55562d1-7338-4aa0-b2da-bcda8c91439f"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""1a750399-6c4d-4b43-95be-6869d6e11983"",
            ""actions"": [
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""f525c33b-c38e-44de-9476-906e2b94da0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""eec6c20a-6eba-4db1-af74-2807e2b8b46d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Camera = m_Gameplay.FindAction("Camera", throwIfNotFound: true);
        m_Gameplay_Sprint = m_Gameplay.FindAction("Sprint", throwIfNotFound: true);
        m_Gameplay_Crouch = m_Gameplay.FindAction("Crouch", throwIfNotFound: true);
        m_Gameplay_RB = m_Gameplay.FindAction("RB", throwIfNotFound: true);
        m_Gameplay_RT = m_Gameplay.FindAction("RT", throwIfNotFound: true);
        m_Gameplay_DPadUp = m_Gameplay.FindAction("DPadUp", throwIfNotFound: true);
        m_Gameplay_DPadDown = m_Gameplay.FindAction("DPadDown", throwIfNotFound: true);
        m_Gameplay_DPadLeft = m_Gameplay.FindAction("DPadLeft", throwIfNotFound: true);
        m_Gameplay_DPadRight = m_Gameplay.FindAction("DPadRight", throwIfNotFound: true);
        m_Gameplay_A = m_Gameplay.FindAction("A", throwIfNotFound: true);
        m_Gameplay_LockOn = m_Gameplay.FindAction("LockOn", throwIfNotFound: true);
        m_Gameplay_Y = m_Gameplay.FindAction("Y", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Inventory = m_UI.FindAction("Inventory", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Camera;
    private readonly InputAction m_Gameplay_Sprint;
    private readonly InputAction m_Gameplay_Crouch;
    private readonly InputAction m_Gameplay_RB;
    private readonly InputAction m_Gameplay_RT;
    private readonly InputAction m_Gameplay_DPadUp;
    private readonly InputAction m_Gameplay_DPadDown;
    private readonly InputAction m_Gameplay_DPadLeft;
    private readonly InputAction m_Gameplay_DPadRight;
    private readonly InputAction m_Gameplay_A;
    private readonly InputAction m_Gameplay_LockOn;
    private readonly InputAction m_Gameplay_Y;
    public struct GameplayActions
    {
        private @MovementActions m_Wrapper;
        public GameplayActions(@MovementActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Camera => m_Wrapper.m_Gameplay_Camera;
        public InputAction @Sprint => m_Wrapper.m_Gameplay_Sprint;
        public InputAction @Crouch => m_Wrapper.m_Gameplay_Crouch;
        public InputAction @RB => m_Wrapper.m_Gameplay_RB;
        public InputAction @RT => m_Wrapper.m_Gameplay_RT;
        public InputAction @DPadUp => m_Wrapper.m_Gameplay_DPadUp;
        public InputAction @DPadDown => m_Wrapper.m_Gameplay_DPadDown;
        public InputAction @DPadLeft => m_Wrapper.m_Gameplay_DPadLeft;
        public InputAction @DPadRight => m_Wrapper.m_Gameplay_DPadRight;
        public InputAction @A => m_Wrapper.m_Gameplay_A;
        public InputAction @LockOn => m_Wrapper.m_Gameplay_LockOn;
        public InputAction @Y => m_Wrapper.m_Gameplay_Y;
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
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Camera.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Crouch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @RB.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRB;
                @RB.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRB;
                @RB.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRB;
                @RT.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRT;
                @RT.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRT;
                @RT.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRT;
                @DPadUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadUp;
                @DPadUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadUp;
                @DPadUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadUp;
                @DPadDown.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadDown;
                @DPadDown.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadDown;
                @DPadDown.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadDown;
                @DPadLeft.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadLeft;
                @DPadRight.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadRight;
                @DPadRight.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadRight;
                @DPadRight.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDPadRight;
                @A.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnA;
                @LockOn.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLockOn;
                @Y.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnY;
                @Y.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnY;
                @Y.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnY;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @RB.started += instance.OnRB;
                @RB.performed += instance.OnRB;
                @RB.canceled += instance.OnRB;
                @RT.started += instance.OnRT;
                @RT.performed += instance.OnRT;
                @RT.canceled += instance.OnRT;
                @DPadUp.started += instance.OnDPadUp;
                @DPadUp.performed += instance.OnDPadUp;
                @DPadUp.canceled += instance.OnDPadUp;
                @DPadDown.started += instance.OnDPadDown;
                @DPadDown.performed += instance.OnDPadDown;
                @DPadDown.canceled += instance.OnDPadDown;
                @DPadLeft.started += instance.OnDPadLeft;
                @DPadLeft.performed += instance.OnDPadLeft;
                @DPadLeft.canceled += instance.OnDPadLeft;
                @DPadRight.started += instance.OnDPadRight;
                @DPadRight.performed += instance.OnDPadRight;
                @DPadRight.canceled += instance.OnDPadRight;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @Y.started += instance.OnY;
                @Y.performed += instance.OnY;
                @Y.canceled += instance.OnY;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Inventory;
    public struct UIActions
    {
        private @MovementActions m_Wrapper;
        public UIActions(@MovementActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Inventory => m_Wrapper.m_UI_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Inventory.started -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnInventory;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnRB(InputAction.CallbackContext context);
        void OnRT(InputAction.CallbackContext context);
        void OnDPadUp(InputAction.CallbackContext context);
        void OnDPadDown(InputAction.CallbackContext context);
        void OnDPadLeft(InputAction.CallbackContext context);
        void OnDPadRight(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnInventory(InputAction.CallbackContext context);
    }
}

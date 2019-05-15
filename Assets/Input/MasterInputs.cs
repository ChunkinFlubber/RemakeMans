// GENERATED AUTOMATICALLY FROM 'Assets/Input/MasterInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Utilities;

public class MasterInputs : IInputActionCollection
{
    private InputActionAsset asset;
    public MasterInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MasterInputs"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""ed029489-dd62-4faa-bcba-699b05a85bd5"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""id"": ""bb5151e3-8c1a-42a3-af69-5fa341945224"",
                    ""expectedControlLayout"": ""Button"",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": true,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Movement"",
                    ""id"": ""8a1e63e3-ecbb-496c-93b2-0c9b45b1d892"",
                    ""expectedControlLayout"": """",
                    ""continuous"": true,
                    ""passThrough"": false,
                    ""initialStateCheck"": true,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Fire"",
                    ""id"": ""271e25ea-4b4c-4619-a9ea-f3b57d5008af"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": true,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""AltFire"",
                    ""id"": ""f464b8eb-4947-43a5-b505-703183e72867"",
                    ""expectedControlLayout"": ""Button"",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": true,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Look"",
                    ""id"": ""47d58db3-c246-452c-ba51-69bdd6c1bf5f"",
                    ""expectedControlLayout"": """",
                    ""continuous"": true,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Sprint"",
                    ""id"": ""1d8601d1-425c-43ba-8291-3648e8814900"",
                    ""expectedControlLayout"": ""Button"",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": true,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ae723358-4b35-4479-8621-efaeee22e2f7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""wasd"",
                    ""id"": ""57676225-6e04-4555-83ee-a2934646fafa"",
                    ""path"": ""2DVector(normalize=false)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1b031639-a717-4352-bb85-95018f24075f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e73f747f-7db1-4b80-8287-16bd49219067"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bd0ee486-e5ba-40d6-9255-3404e81e4836"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": ""right"",
                    ""id"": ""28d38384-044f-427c-8934-77bee7c178bb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""15c12795-0de6-4051-a628-dd206eb61c4d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""b6aca9dd-2369-49f5-bb58-6b59135cb5b9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""b4f228c6-0df6-4d2e-83ef-955acd629bd4"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""80d5f463-2abd-4907-8c42-3171107d0f6a"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character
        m_Character = asset.GetActionMap("Character");
        m_Character_Jump = m_Character.GetAction("Jump");
        m_Character_Movement = m_Character.GetAction("Movement");
        m_Character_Fire = m_Character.GetAction("Fire");
        m_Character_AltFire = m_Character.GetAction("AltFire");
        m_Character_Look = m_Character.GetAction("Look");
        m_Character_Sprint = m_Character.GetAction("Sprint");
    }
    ~MasterInputs()
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
    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }
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
    // Character
    private InputActionMap m_Character;
    private ICharacterActions m_CharacterActionsCallbackInterface;
    private InputAction m_Character_Jump;
    private InputAction m_Character_Movement;
    private InputAction m_Character_Fire;
    private InputAction m_Character_AltFire;
    private InputAction m_Character_Look;
    private InputAction m_Character_Sprint;
    public struct CharacterActions
    {
        private MasterInputs m_Wrapper;
        public CharacterActions(MasterInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump { get { return m_Wrapper.m_Character_Jump; } }
        public InputAction @Movement { get { return m_Wrapper.m_Character_Movement; } }
        public InputAction @Fire { get { return m_Wrapper.m_Character_Fire; } }
        public InputAction @AltFire { get { return m_Wrapper.m_Character_AltFire; } }
        public InputAction @Look { get { return m_Wrapper.m_Character_Look; } }
        public InputAction @Sprint { get { return m_Wrapper.m_Character_Sprint; } }
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
            {
                Jump.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                Jump.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnJump;
                Movement.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                Movement.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                Fire.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnFire;
                Fire.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnFire;
                Fire.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnFire;
                AltFire.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAltFire;
                AltFire.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAltFire;
                AltFire.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnAltFire;
                Look.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLook;
                Look.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLook;
                Look.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnLook;
                Sprint.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprint;
                Sprint.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprint;
                Sprint.cancelled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_CharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.cancelled += instance.OnJump;
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.cancelled += instance.OnMovement;
                Fire.started += instance.OnFire;
                Fire.performed += instance.OnFire;
                Fire.cancelled += instance.OnFire;
                AltFire.started += instance.OnAltFire;
                AltFire.performed += instance.OnAltFire;
                AltFire.cancelled += instance.OnAltFire;
                Look.started += instance.OnLook;
                Look.performed += instance.OnLook;
                Look.cancelled += instance.OnLook;
                Sprint.started += instance.OnSprint;
                Sprint.performed += instance.OnSprint;
                Sprint.cancelled += instance.OnSprint;
            }
        }
    }
    public CharacterActions @Character
    {
        get
        {
            return new CharacterActions(this);
        }
    }
    public interface ICharacterActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnAltFire(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
}

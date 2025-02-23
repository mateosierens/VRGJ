using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Inputs
{
    public enum SideController
    {
        LeftHand,
        RightHand
    }
    
    public class InputManager : MonoBehaviour
    {
        
        public static InputManager Instance { get; private set; }

        private ActionBasedController leftController;
        private ActionBasedController rightController;
        
        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            }
        }
        
        // Start is called before the first frame update
        void Start()
        {
            leftController = GameObject.Find("Left Controller").GetComponent<ActionBasedController>();
            rightController = GameObject.Find("Right Controller").GetComponent<ActionBasedController>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool sendHaptics(SideController sideController, float amplitude, float duration)
        {

            switch (sideController)
            {
                case SideController.LeftHand:
                    leftController.SendHapticImpulse(amplitude, duration);
                    return true;
                case SideController.RightHand:
                    rightController.SendHapticImpulse(amplitude, duration);
                    return true;
                default:
                    Debug.Log("HOW DID YOU GET HERE????");
                    return false;
            }
        }
        
        
    }

}

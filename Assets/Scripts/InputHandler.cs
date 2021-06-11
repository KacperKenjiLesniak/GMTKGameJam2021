using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Physiurg
{
    public class InputHandler : MonoBehaviour
    {
        public List<PhysicManipulator> physicManipulators;
        public float inputScaler = 1f;
        private int activeManipulator = 1;
        
        private void Start()
        {
            if (physicManipulators.Count == 0) Debug.LogError("No physic manipulators provided"); 
        }

        void Update()
        {
            int numberPressed = GetPressedNumber();

            if (numberPressed > -1 && numberPressed <= physicManipulators.Count)
            {
                activeManipulator = numberPressed;
            }
            
            ScaleInput();
            
            physicManipulators[activeManipulator - 1].Scale(Input.GetAxis("Vertical") * inputScaler);
        }
        
        private int GetPressedNumber() {
            for (var number = 0; number <= 9; number++) {
                if (Input.GetKeyDown(number.ToString()))
                    return number;
            }
 
            return -1;
        }

        private void ScaleInput()
        {
            if (Input.GetAxis("Vertical") > 0f)
            {
                inputScaler += Time.deltaTime * 5;
            }
            else if (Input.GetAxis("Vertical") < 0f)
            {
                inputScaler += Time.deltaTime * 5;
            }
            else
            {
                inputScaler = 1f;
            }
        }
    }
}
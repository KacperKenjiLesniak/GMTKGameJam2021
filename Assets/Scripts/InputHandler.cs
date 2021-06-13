using System;
using System.Collections.Generic;
using GameEvents.Game;
using UnityEngine;

namespace DefaultNamespace.Physiurg
{
    public class InputHandler : MonoBehaviour
    {
        public List<PhysicManipulator> physicManipulators;
        public float inputScaler = 4f;
        public GameEvent startGame;
        
        private int activeManipulator = 1;
        
        private void Start()
        {
            if (physicManipulators.Count == 0) Debug.LogError("No physic manipulators provided"); 
            SelectManipulator();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startGame.RaiseGameEvent();
            }
            
            int numberPressed = GetPressedNumber();

            if (numberPressed > -1 && numberPressed <= physicManipulators.Count)
            {
                activeManipulator = numberPressed;
                SelectManipulator();
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                activeManipulator -= 1;
                if (activeManipulator == 0) activeManipulator = physicManipulators.Count;
                SelectManipulator();
            }
            
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                activeManipulator = activeManipulator % physicManipulators.Count + 1 ;
                SelectManipulator();
            }

            physicManipulators[activeManipulator - 1].Scale(
                Input.GetAxis("Horizontal") * inputScaler
                );
        }

        private void SelectManipulator()
        {
            for (var i = 0; i < physicManipulators.Count; i++)
            {
                physicManipulators[i].SetSelected(i == activeManipulator - 1);
            }
        }

        private int GetPressedNumber() {
            for (var number = 0; number <= 9; number++) {
                if (Input.GetKeyDown(number.ToString()))
                    return number;
            }
 
            return -1;
        }
    }
}
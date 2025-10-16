using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Infrastructure.Input
{
    public class InputReader : IInputReader
    {
        private InputSystemActions _input = new();

        public event Action<Vector2> MovedDirection; 
        public event Action Interacted; 
        public event Action Attacked; 
        
        public void Enable()
        {
            _input.Player.Enable();
            
            _input.Player.Move.performed += OnMovePerformed;
            _input.Player.Interact.performed += OnInteractPerformed;
            _input.Player.Attack.performed += OnAttackPerformed;
        }

        private void OnAttackPerformed(InputAction.CallbackContext context) => 
            Attacked?.Invoke();

        private void OnInteractPerformed(InputAction.CallbackContext context) => 
            Interacted?.Invoke();

        private void OnMovePerformed(InputAction.CallbackContext context) => 
            MovedDirection?.Invoke(context.ReadValue<Vector2>());

        public void Disable()
        {
            _input.Player.Disable();
            
            _input.Player.Move.performed -= OnMovePerformed;
            _input.Player.Interact.performed -= OnInteractPerformed;
            _input.Player.Attack.performed -= OnAttackPerformed;
        }
    }
}
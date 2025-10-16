using System;
using UnityEngine;

namespace Source.Infrastructure.Input
{
    public interface IInputReader
    {
        void Enable();
        void Disable();
        event Action<Vector2> MovedDirection;
        event Action Interacted;
        event Action Attacked;
    }
}
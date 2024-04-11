using UnityEngine;

namespace InteractablePoint
{
    public interface IInteractablePoint
    {
        public Vector3 Position { get; }
        public InteractableType Type { get; }
        
    }
}
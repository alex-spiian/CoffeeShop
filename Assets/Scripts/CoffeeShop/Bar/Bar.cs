using System;
using InteractablePoint;
using UnityEngine;

namespace CoffeeShop.Bar
{
    public class Bar : MonoBehaviour, IInteractablePoint
    {
        [field:SerializeField]
        public InteractableType Type { get; private set; }
        [field:SerializeField] public Queue Queue { get; private set; }

        public Vector3 Position { get; }

        private void Awake()
        {
            Queue.Initialize(transform);
        }
    }
}
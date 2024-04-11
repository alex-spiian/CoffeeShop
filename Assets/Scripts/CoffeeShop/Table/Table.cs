using System;
using UnityEngine;

namespace CoffeeShop.Table
{
    public class Table : MonoBehaviour
    {
        [field:SerializeField] public int Price { get; private set; }
        [SerializeField] private Transform _seat;
        public bool IsAvailable;
        private int _busySeatsCount;

        private void Awake()
        {
            Debug.Log("table");
            IsAvailable = true;
        }

        public Vector3 GetSeatPosition()
        {
            IsAvailable = false;
            return _seat.position;
        }
    }
}
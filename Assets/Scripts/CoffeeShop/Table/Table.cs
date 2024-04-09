using UnityEngine;

namespace CoffeeShop.Table
{
    public class Table : MonoBehaviour
    {
        [SerializeField] private Transform[] _seats;
        public bool IsAvailable => _seats.Length > _busySeatsCount;
        private int _busySeatsCount;

        public Vector3 GetSeatPosition()
        {
            // TODO add checking of really available seats
            return _seats[0].position;
        }
    }
}
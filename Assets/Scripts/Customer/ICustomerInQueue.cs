
using UnityEngine;

namespace Customer
{
    public interface ICustomerInQueue : IMovable
    {
        public Vector3 PositionInLine { get; }

        public void SetPositionInLine(Vector3 position);

    }
}
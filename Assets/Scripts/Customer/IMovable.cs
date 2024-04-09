using System;
using UnityEngine;

namespace Customer
{
    public interface IMovable
    {
        public void Move(Vector3 targetPosition, Action CameToTarget);
    }
}
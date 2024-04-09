using System;
using UnityEngine;
using UnityEngine.AI;

namespace Customermovement
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        private event Action CameToTarget;
        private bool _cameToTarget;


        private void Update()
        {
            if (IsAtTargetPoint() && !_cameToTarget)
            {
                CameToTarget?.Invoke();
                _cameToTarget = true;
            }
        }
        
        private bool IsAtTargetPoint()
        {
            if (_navMeshAgent.pathPending) return false;
            return _navMeshAgent.remainingDistance < 1f;
        }

        public void Move(Vector3 targetPosition, Action CameToTarget)
        {
            _cameToTarget = false;
            this.CameToTarget = CameToTarget;
            _navMeshAgent.SetDestination(targetPosition);
        }
    }
}
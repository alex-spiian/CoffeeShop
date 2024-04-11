using System;
using System.Collections.Generic;
using Customer;
using UnityEngine;

[Serializable]
public class Queue
{
    [field:SerializeField] public Vector3 ShiftForNextPosition { get; private set; }

    private Transform _firstPositionInQueue;
    private Vector3 _lastBusyPositionInQueue;
    private readonly List<ICustomerInQueue> _customersInLine = new();
    private bool _isBusy;

    public void Initialize(Transform pointForCustomers)
    {
        _firstPositionInQueue = pointForCustomers;
        _lastBusyPositionInQueue = _firstPositionInQueue.position;
    }
    
    public Vector3 GetFreePosition(ICustomerInQueue customer)
    {
        _customersInLine.Add(customer);
        
        if (_firstPositionInQueue.position == _lastBusyPositionInQueue && !_isBusy)
        {
            _isBusy = true;
            customer.SetPositionInLine(_firstPositionInQueue.position);
            return _firstPositionInQueue.position;
        }
        customer.SetPositionInLine(_lastBusyPositionInQueue += ShiftForNextPosition);
        return _lastBusyPositionInQueue += ShiftForNextPosition;
    }
    
    
    public void OnCustomerLeft(ICustomerInQueue customer)
    {
        _customersInLine.Remove(customer);
        if (_lastBusyPositionInQueue == _firstPositionInQueue.position)
        {
            _isBusy = false;
            return;
        }
        _lastBusyPositionInQueue -= ShiftForNextPosition;
        MoveCustomersForward();
    }

    private void MoveCustomersForward()
    {
        foreach (var customer in _customersInLine)
        {
            var destination = customer.PositionInLine - ShiftForNextPosition;
            customer.SetPositionInLine(destination);
            customer.Move(destination);
        }
    }
}
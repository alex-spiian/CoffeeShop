using System;
using NegotiationSystem;
using UnityEngine;

namespace Customer
{
    [Serializable]
    public class AnswerOption
    {
        [field:SerializeField] public MessageType Type { get; private set; }
        [field:SerializeField] public string Option { get; private set; }

    }
}
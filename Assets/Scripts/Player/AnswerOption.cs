using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class AnswerOption
    {
        [field:SerializeField] public Product.ProductType ProductType { get; private set; }
        [field:SerializeField] public string Option { get; private set; }
    }
}
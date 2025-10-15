using System;
using UnityEngine;

namespace Source.Domain.Stats
{
    [Serializable]
    public class Stat
    {
        public Stat(StatType type, float value, bool isMultiplier)
        {
            Type = type;
            Value = value;
            IsMultiplier = isMultiplier;
        }

        public Stat(Stat stat)
        {
            Type = stat.Type;
            Value = stat.Value;
            IsMultiplier = stat.IsMultiplier;
        }
        
        [field: SerializeField]
        public float Value { get; private set; }

        [field: SerializeField]
        public bool IsMultiplier  { get; private set; }

        [field: SerializeField]
        public StatType Type  { get; private set; }
    }
}
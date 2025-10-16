using System;
using UnityEngine;

namespace Source.Infrastructure.Scriptables
{
    [Serializable]
    public struct BootObjectsData
    {
        public string Tag;
        public GameObject Prefab;
        public Vector3 Position;
    }
}

using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BootObjectsDataBase", menuName = "Scriptable Objects/DataBases/Boot/BootObjectsDataBase")]
public class BootObjectsDataBase : ScriptableObject
{
    [SerializeField] private BootObjectsData[] _allPrefabs;

    public BootObjectsData GetPrefabByTag(string tag)
    {
        return _allPrefabs.First(x => x.Tag == tag);
    }
}

using Source.Infrastructure.Scriptables;
using UnityEngine;

namespace Source.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] BootObjectsDataBase _bootObjectsData;

        private void Awake()
        {
            InittializeScene();
        }

        private void InittializeScene()
        {

        }
    }
}

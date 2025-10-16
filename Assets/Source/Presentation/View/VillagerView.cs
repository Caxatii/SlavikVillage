using Source.ContractInterfaces;
using UnityEngine;

namespace Source.Presentation.View
{
    public class VillagerView : MonoBehaviour, IAnimatedView
    {
        [SerializeField] private Animator _animator;
        
        public void Play(int animationHash)
        {
            _animator.Play(animationHash);
        }
    }
}
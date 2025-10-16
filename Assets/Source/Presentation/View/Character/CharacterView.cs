using Source.Infrastructure.ContractsInterfaces.Character;
using Source.Infrastructure.Presenters.Animation;
using System.Linq;
using UnityEngine;

namespace Source.Presentation.View.Character
{
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterVFXData[] _vfxSetiings;

        public void SetAnimationState(AnimationData data)
        {
            if(data.Type == AnimationType.Trigger)
                _animator.SetTrigger(data.State.ToString());

            if (data.Type == AnimationType.Bool)
                _animator.SetBool(data.State.ToString(), data.IsPlaying);
        }

        public void PlayVFX(AnimationData data)
        {
            _vfxSetiings.First(x => x.Type == data.State).VFX.Play();
        }
    }
}

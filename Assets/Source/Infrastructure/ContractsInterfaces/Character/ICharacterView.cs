using Source.Infrastructure.Presenters.Animation;
using UnityEngine;

namespace Source.Infrastructure.ContractsInterfaces.Character
{
    public interface ICharacterView
    {
        public void SetAnimationState(AnimationData data);

        public void PlayVFX(AnimationData data);
    }
}

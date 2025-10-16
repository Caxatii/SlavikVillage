using Source.Infrastructure.DataTransfer;
using UnityEngine;

namespace Source.Infrastructure.Presenters.Animation
{
    public struct AnimationData
    {
        public readonly AnimationStateType State;
        public readonly AnimationType Type;
        public readonly bool IsPlaying;

        public AnimationData(AnimationStateType state, AnimationType type = AnimationType.Trigger, bool isPlaying = false)
        {
            State = state;
            Type = type;
            IsPlaying = isPlaying;
        }
    }
}

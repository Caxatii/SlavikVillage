using Source.Infrastructure.Presenters.Animation;

namespace Source.Infrastructure.DataTransfer
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

using Source.Infrastructure.ContractsInterfaces.Character;
using Source.Infrastructure.Presenters.Animation;
using System.Linq;
using UnityEngine;

namespace Source.Presentation.View.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        private Rigidbody2D _characterRigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterVFXData[] _vfxSetiings;

        private void Awake()
        {
            _characterRigidbody = GetComponent<Rigidbody2D>();
        }

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

        public void Move(Vector2 direction)
        {
            _characterRigidbody.linearVelocityX = direction.x;

            if (direction.x > 0)
                transform.localScale = new Vector2(-1, transform.localScale.y);
            else
                transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }
}

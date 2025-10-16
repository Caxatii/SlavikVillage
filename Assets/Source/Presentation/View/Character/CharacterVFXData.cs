using System;
using Source.Infrastructure.Presenters.Animation;
using UnityEngine;

namespace Source.Presentation.View.Character
{
    [Serializable]
    public struct CharacterVFXData
    {
        [SerializeField] private AnimationStateType _type;
        [SerializeField] private ParticleSystem _vfx;

        public AnimationStateType Type => _type;
        public ParticleSystem VFX => _vfx;
    }
}

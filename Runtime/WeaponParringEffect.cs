using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility.EffectObject
{
    public class WeaponParringEffect : EffectObject
    {
        [SerializeField] private ParticleSystem sparkParticle;

        protected override void OnEffect(Action completeListener)
        {
            sparkParticle?.Play();
            completeListener?.Invoke();
        }

    }
}

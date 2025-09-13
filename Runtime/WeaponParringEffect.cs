using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility.EffectObject
{
    public class WeaponParringEffect : EffectObject
    {
        [SerializeField] private ParticleSystem sparkParticle;

        private IEnumerator effectLifeTimeHandle;
        private readonly WaitForSeconds LIFE_TIME = new WaitForSeconds(3);

        protected override void OnEffect(Action completeListener)
        {
            sparkParticle?.Play();

            if (effectLifeTimeHandle!=null) StopCoroutine(effectLifeTimeHandle);
            StartCoroutine(effectLifeTimeHandle = EffectLifeTime(completeListener));
        }

        protected override void OffEffect()
        {
            sparkParticle?.Stop();
        }

        private IEnumerator EffectLifeTime(Action completeListener)
        {
            yield return LIFE_TIME;

            completeListener?.Invoke();
        }
    }
}

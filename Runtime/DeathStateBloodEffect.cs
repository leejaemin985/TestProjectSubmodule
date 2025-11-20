using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility.EffectObject
{
    public class DeathStateBloodEffect : EffectObject
    {
        [SerializeField] private ParticleSystem bloodEffect;

        private IEnumerator lifeTimeHandle;
        private WaitForSeconds EFFECT_LIFE_SEC = new(2);

        protected override void OnEffect(Action completeListener)
        {
            bloodEffect.Play();

            if (lifeTimeHandle != null) StopCoroutine(lifeTimeHandle);
            StartCoroutine(lifeTimeHandle=EffectLifeTime(completeListener));
        }

        protected override void OffEffect()
        {
            bloodEffect.Stop();
        }

        private IEnumerator EffectLifeTime(Action completeListener)
        {
            yield return EFFECT_LIFE_SEC;
            completeListener?.Invoke();
        }
    }
}

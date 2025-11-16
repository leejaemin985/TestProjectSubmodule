using System;
using System.Collections;
using UnityEngine;

namespace Utility.EffectObject
{
    public class HitStateSparkEffect : EffectObject
    {
        [SerializeField] private ParticleSystem sparkEffect;

        private IEnumerator lifeTimeHandle;
        private WaitForSeconds EFFECT_LIFE_SEC = new(2);

        protected override void OnEffect(Action completeListener)
        {
            sparkEffect.Play();

            if (lifeTimeHandle != null) StopCoroutine(lifeTimeHandle);
            StartCoroutine(lifeTimeHandle = EffectLifeTime(completeListener));
        }

        protected override void OffEffect()
        {
            sparkEffect.Stop();
        }

        private IEnumerator EffectLifeTime(Action completeListener)
        {
            yield return EFFECT_LIFE_SEC;
            completeListener?.Invoke();
        }
    }
}
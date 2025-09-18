using System;
using System.Collections;
using UnityEngine;

namespace Utility.EffectObject
{
    public class RoarStateEffect : EffectObject
    {
        [SerializeField] private ParticleSystem distorationEffect;
        [SerializeField] private ParticleSystem[] fogEffect;

        [SerializeField] private Renderer decalRenderer;
        [SerializeField] private float decalEffectDuration;
        [SerializeField] private AnimationCurve decalPropCurve;

        private MaterialPropertyBlock decalProps;
        private int decalPropertyId;
        private IEnumerator decalEffectHandle;

        private Action completeEvent;

        protected override void Initialize()
        {
            if (decalProps == null) decalProps = new MaterialPropertyBlock();
            decalPropertyId = Shader.PropertyToID("_Cutout");
        }

        protected override void OnEffect(Action completeListener)
        {
            distorationEffect?.Play();
            foreach (var fog in fogEffect) fog?.Play();

            if (decalEffectHandle != null) StopCoroutine(decalEffectHandle);
            StartCoroutine(decalEffectHandle = DecalEffect());

            this.completeEvent = completeListener;
        }

        protected override void OffEffect()
        {
            distorationEffect?.Stop();
            foreach (var fog in fogEffect) fog?.Stop();

            if (decalEffectHandle != null) StopCoroutine(decalEffectHandle);
        }

        private IEnumerator DecalEffect()
        {
            float temp = decalEffectDuration;
            while (temp > 0)
            {
                var eval = 1 - (temp / decalEffectDuration);
                decalProps.SetFloat(decalPropertyId, decalPropCurve.Evaluate(eval));
                decalRenderer.SetPropertyBlock(decalProps);

                temp -= Time.deltaTime;
                yield return null;
            }

            completeEvent?.Invoke();
        }
    }
}
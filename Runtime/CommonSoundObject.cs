using Codice.CM.Common;
using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Utility.Sound
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class CommonSoundObject<TEnum> : MonoBehaviour, ISoundObject where TEnum : Enum
    {
        private bool initialized = false;
        private AudioSource audioSource = default;
        protected virtual float spatialBlendSetting => 1f;

        public AudioSource Audio
        {
            get
            {
                if (initialized == false) throw new InvalidOperationException("SoundObject is not initialized.");
                if (audioSource == null)
                {
                    audioSource = GetComponent<AudioSource>();
                    audioSource.spatialBlend = spatialBlendSetting;
                }
                return audioSource;
            }
        }

        public abstract TEnum SoundType { get; }

        public virtual void Initialize(AudioMixerGroup outputGroup)
        {
            if (outputGroup == null) return;

            initialized = true;
            Audio.outputAudioMixerGroup = outputGroup;
        }

        public void PlayOneShot(AudioClip audioClip)
        {
            Audio.PlayOneShot(audioClip);
        }
    }
}
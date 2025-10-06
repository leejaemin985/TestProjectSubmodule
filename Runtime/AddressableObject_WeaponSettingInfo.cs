using CustomPhysics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.EffectObject;

namespace Addressable
{
    public class AddressableObject_WeaponSettingInfo : MonoBehaviour
    {
        [Header("Equip")]
        public Vector3 weaponLocalPos;
        public Vector3 weaponLocalRot;

        [Header("Physics")]
        public PhysicsObject collisionBox;

        [Header("Effect")]
        public ParticleSystem trailParticle;
        public EffectObject slashEffect;
        public EffectObject parringEffect;

        [Header("Sound")]
        public AudioClip[] whooshSoundClips;
        public AudioClip[] collisionSoundClips;
    }
}

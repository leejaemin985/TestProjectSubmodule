using Unity.Profiling;
using UnityEngine;

namespace Utility.Sound
{
    public interface ISoundObject
    {
        void PlayOneShot(AudioClip clip);
    }
}
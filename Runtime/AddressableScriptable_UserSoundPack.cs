using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Addressable
{
    [CreateAssetMenu(fileName = "UserSoundPack", menuName = "Scriptable/AddressableScriptable/UserSoundPack")]
    public class AddressableScriptable_UserSoundPack : ScriptableObject
    {
        [Header("FSM State")]
        [SerializeField] private AudioClip roarStateSE;
    }
}

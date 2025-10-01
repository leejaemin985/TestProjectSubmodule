using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Addressable
{
    public class AddressableObject_UserModelSettingInfo : MonoBehaviour
    {
        [Header("Weapon")]
        public Transform weaponParentTransform;

        [Header("Cam")]
        public Transform defaultCamPos;
        public Transform actionCamPos;
    }
}

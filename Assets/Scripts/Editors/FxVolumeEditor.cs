using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Sirenix.OdinInspector;

[ExecuteInEditMode]
[RequireComponent(typeof(Volume))]
public class FxVolumeEditor : MonoBehaviour
{
    [SerializeField] List<VolumeProfile> profiles;

    [ValueDropdown("profiles")]
    [SerializeField] VolumeProfile activeProfile;
    private Volume volume;
    private void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile = activeProfile;
    }

    private void OnValidate()
    {
        if (volume != null) volume.profile = activeProfile;
    }
}

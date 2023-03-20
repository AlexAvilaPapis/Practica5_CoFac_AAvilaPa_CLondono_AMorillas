using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AudioFile
{
    [Range(0, 1)] public float LocalVolume;
    public string AudioName;
    public AudioClip Clip;
}

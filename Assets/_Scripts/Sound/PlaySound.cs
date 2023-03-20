using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySound : MonoBehaviour
{
    public void ReproduceSound(string name)
    {
        SoundManager.PlaySFX(name);        
    }
}

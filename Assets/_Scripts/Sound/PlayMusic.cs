using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField]
    private string _name;

    private void Start()
    {
        SoundManager.PlayMusic(_name);
    }
}

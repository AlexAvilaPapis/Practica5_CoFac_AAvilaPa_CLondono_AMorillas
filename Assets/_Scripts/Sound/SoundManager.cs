using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

using System.Linq;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private List<AudioFile> MusicList = new List<AudioFile>();
    [SerializeField] private List<AudioFile> SFXList = new List<AudioFile>();

    [SerializeField] AudioSource _AudioSourceSFX;
    [SerializeField] AudioSource _AudioSourceMusic;
    [SerializeField] AudioMixer _AudioMixer;

    [SerializeField, Range(0, 1)] float _GlobalVolume;
    [SerializeField, Range(0, 1)] float _GlobalMusicVolume;
    [SerializeField, Range(0, 1)] float _GlobalSFXVolume;

    [SerializeField] private bool IsMusicLoop;
    public bool Muted;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        DontDestroyOnLoad(Instance.gameObject);
    }
    private void Start()
    {
        Instance._AudioSourceMusic.loop = IsMusicLoop;
    }

    void _PlayMusic(string name)
    {
        var file = GetMusicFileByName(name);
        if (file != null)
        {
            var clip = file.Clip;

            if (clip != null)
            {
                _AudioSourceMusic.clip = clip;
                _AudioSourceMusic.Play();
            }
            else
            {
                Debug.LogError("Clip of " + name + " is null");
            }
        }
        else
        {
            Debug.LogError(name + " Music not Found");
        }
    }

    void _PlaySFX(string name, AudioSource source)
    {
        var file = GetSFXFileByName(name);
        if (file != null)
        {
            var clip = file.Clip;
            source.volume = file.LocalVolume * _GlobalSFXVolume * _GlobalVolume;

            if (_AudioMixer.FindMatchingGroups("SFX").Length > 0)
            {
                if (_AudioMixer.FindMatchingGroups("SFX/" + name).Length > 0)
                {
                    source.outputAudioMixerGroup = _AudioMixer.FindMatchingGroups("SFX/" + name)[0];
                    //Debug.Log(name + " Found");
                }
            }
            else
            {
                source.outputAudioMixerGroup = _AudioMixer.FindMatchingGroups("SFX")[0];
                Debug.Log(name + " Not found");
            }


            if (clip != null)
            {
                source.clip = clip;
                source.Play();
                //Debug.Log(name + " Se reproduce");
            }
        }
        else
        {
            Debug.LogError(name + "Clip not found");
        }
    }

    AudioFile GetMusicFileByName(string name)
    {
        AudioFile file = null;
        if (MusicList.Exists(x => x.AudioName == name)) file = MusicList.First<AudioFile>(x => x.AudioName == name);
        else Debug.LogError(name + " doesn't mathc any item in MusicList");
        if (file != null) return file;
        Debug.LogError(name + " file not found");
        return null;
    }

    AudioFile GetSFXFileByName(string name)
    {
        AudioFile file = null;
        if (SFXList.Exists(x => x.AudioName == name)) file = SFXList.First<AudioFile>(x => x.AudioName == name);
        else Debug.LogError(name + " doesn't match any item in SFXList");
        if (file != null) return file;
        return null;
    }

    //Instance shortcuts

    public static AudioSource AudioSourceSFX
    {
        get => Instance._AudioSourceSFX;
    }

    public static AudioSource AudioSourceMusic
    {
        get => Instance._AudioSourceMusic;
    }

    public static float GlobalVolume
    {
        get => Instance._GlobalVolume;
        set => Instance._GlobalVolume = value;
    }

    public static float GlobalMusicVolume
    {
        get => Instance._GlobalMusicVolume;
        set => Instance._GlobalMusicVolume = value;
    }

    public static float GlobalSFXVolume
    {
        get => Instance._GlobalSFXVolume;
        set => Instance._GlobalSFXVolume = value;
    }

    public static void PlayMusic(string name)
    {
        Instance._PlayMusic(name);
    }

    public static void PlaySFX(string name)
    {
        Instance._PlaySFX(name, Instance._AudioSourceSFX);
    }

    public static void PlaySFX(string name, AudioSource source)
    {
        Instance._PlaySFX(name, source);
    }
}



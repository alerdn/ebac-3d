using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private List<MusicSetup> _musicSetups;
    [SerializeField] private List<SFXSetup> _sfxSetups;
    [SerializeField] private AudioMixer _mixer;

    private bool _isMusicOn = true;
    private bool _isSFXOn = true;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public MusicSetup GetMusicSetupByType(MusicType type)
    {
        return _musicSetups.Find(setup => setup.MusicType == type);
    }

    public SFXSetup GetSFXSetupByType(SFXType type)
    {
        return _sfxSetups.Find(setup => setup.SFXType == type);
    }

    public bool ToggleMusic()
    {
        _isMusicOn = !_isMusicOn;
        _mixer.SetFloat("VolumeAmbience", _isMusicOn ? 0f : -80f);

        return _isMusicOn;
    }

    public bool ToggleSFX()
    {
        _isSFXOn = !_isSFXOn;
        _mixer.SetFloat("VolumeSFX", _isSFXOn ? 0f : -80f);

        return _isSFXOn;
    }
}

public enum MusicType
{
    AMBIENCE_SPACE,
    AMBIENCE_HIVE
}

[System.Serializable]
public class MusicSetup
{
    public MusicType MusicType;
    public AudioClip AudioClip;
}

public enum SFXType
{
    NONE,
    COIN,
    LIFE_PACK,
    SIMPLE_SHOT,
    MULTIPLE_SHOT
}

[System.Serializable]
public class SFXSetup
{
    public SFXType SFXType;
    public AudioClip AudioClip;
}
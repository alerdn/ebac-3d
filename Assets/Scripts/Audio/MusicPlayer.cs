using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private MusicType _type;
    [SerializeField] private AudioSource _audioSource;

    private MusicSetup _currentMusicSetup;

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        _currentMusicSetup = AudioManager.Instance.GetMusicSetupByType(_type);

        _audioSource.clip = _currentMusicSetup.AudioClip;
        _audioSource.Play();
    }
}

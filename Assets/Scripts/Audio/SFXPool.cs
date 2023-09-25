using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXPool : Singleton<SFXPool>
{
    [SerializeField] private int _poolSize;
    [SerializeField] private AudioMixerGroup _mixer;

    private List<AudioSource> _audioSourceList;
    private int _index = 0;

    private void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _audioSourceList = new List<AudioSource>();

        for (int i = 0; i < _poolSize; i++)
        {
            CreateAudioSourceItem();
        }
    }

    private void CreateAudioSourceItem()
    {
        GameObject go = new GameObject("SFX_Pool");
        go.transform.SetParent(gameObject.transform);

        AudioSource audioSrc = go.AddComponent<AudioSource>();
        audioSrc.outputAudioMixerGroup = _mixer;
        _audioSourceList.Add(audioSrc);
    }

    public void Play(SFXType type)
    {
        if (type == SFXType.NONE) return;

        SFXSetup sfx = AudioManager.Instance.GetSFXSetupByType(type);

        _audioSourceList[_index].clip = sfx.AudioClip;
        _audioSourceList[_index].Play();

        _index++;
        if (_index >= _audioSourceList.Count) _index = 0;
    }
}

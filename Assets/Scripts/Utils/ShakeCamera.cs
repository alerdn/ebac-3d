using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using NaughtyAttributes;

public class ShakeCamera : Singleton<ShakeCamera>
{
    [SerializeField] private List<CinemachineVirtualCamera> _cameras;

    private List<CinemachineBasicMultiChannelPerlin> shakeComponents;
    private float _shakeTime;

    private void Start()
    {
        shakeComponents = new List<CinemachineBasicMultiChannelPerlin>();
        _cameras.ForEach(camera => shakeComponents.Add(camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>()));
    }

    private void Update()
    {
        if (_shakeTime > 0)
        {
            _shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeComponents.ForEach(component =>
            {
                component.m_AmplitudeGain = 0f;
                component.m_FrequencyGain = 0f;
            });
        }
    }

    public void Shake(float amplitude, float frequency, float time)
    {
        shakeComponents.ForEach(component =>
            {
                component.m_AmplitudeGain = amplitude;
                component.m_FrequencyGain = frequency;
            });

        _shakeTime = time;
    }
}

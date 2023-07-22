using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EffectManager : Singleton<EffectManager>
{
    [SerializeField] private PostProcessVolume _volume;

    [Header("Vignette")]
    [SerializeField] private float _flashDuration = 1f;

    private Vignette _vignette;

    public void ChangeVignette()
    {
        StartCoroutine(FlashColorVignette());
    }

    private IEnumerator FlashColorVignette()
    {
        if (_volume.profile.TryGetSettings<Vignette>(out _vignette))
        {
            ColorParameter cp = new ColorParameter();

            float time = 0f;
            while (time < _flashDuration)
            {
                cp.value = Color.Lerp(Color.black, Color.red, time / _flashDuration);
                time += Time.deltaTime;

                _vignette.color.Override(cp);
                yield return new WaitForEndOfFrame();
            }

            time = 0f;
            while (time < _flashDuration)
            {
                cp.value = Color.Lerp(Color.red, Color.black, time / _flashDuration);
                time += Time.deltaTime;

                _vignette.color.Override(cp);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}

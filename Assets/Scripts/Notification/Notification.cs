using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class Notification : Singleton<Notification>
{
    private TMP_Text _notification;
    private Coroutine _routine;

    private void Start()
    {
        _notification = GetComponent<TMP_Text>();
        _notification.text = "";
    }

    public void ShowNotification(string text, float duration, float fadeInDuration = .25f, float fadeOutDuration = .5f)
    {
        if (_routine != null) StopCoroutine(_routine);
        _routine = StartCoroutine(NotificationRoutine(text, duration, fadeInDuration, fadeOutDuration));
    }

    private IEnumerator NotificationRoutine(string text, float time, float fadeInDuration, float fadeOutDuration)
    {
        _notification.text = text;
        _notification.CrossFadeColor(Color.white, fadeInDuration, true, true);

        yield return new WaitForSeconds(time);

        _notification.CrossFadeColor(new Color(0f, 0f, 0f, 0f), fadeOutDuration, true, true);
        yield return new WaitForSeconds(.5f);
        _notification.text = "";

        _routine = null;
    }
}

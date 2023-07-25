using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    [SerializeField] private ItemType _type;

    [Header("Setup")]
    [SerializeField] private string compareTag = "Player";
    [SerializeField] private ParticleSystem mParticleSystem;
    [SerializeField] private float timeToHide = 3;
    [SerializeField] private GameObject graphicItem;

    [Header("Sounds")]
    [SerializeField] private AudioSource audioSource;

    private Collider[] _colliders;

    private void Awake()
    {
        _colliders = GetComponents<Collider>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        graphicItem.SetActive(false);
        foreach (Collider collider in _colliders) collider.enabled = false;
        Invoke(nameof(HideObject), timeToHide);
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (mParticleSystem != null) mParticleSystem.Play();
        if (audioSource != null) audioSource.Play();
        ItemManager.Instance.AddByType(_type);
    }
}

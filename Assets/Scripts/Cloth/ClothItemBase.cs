using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothItemBase : MonoBehaviour
{
    [SerializeField] protected ClothType clothType;
    [SerializeField] protected float duration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Collect();
        }
    }

    public virtual void Collect()
    {
        ClothSetup setup = ClothManager.Instance.GetSetupByType(clothType);
        Player.Instance.ChangeTexture(setup, duration);
        HideObject();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
}

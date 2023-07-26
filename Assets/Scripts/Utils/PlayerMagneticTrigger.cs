using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagneticTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ItemCollectableBase item = other.transform.GetComponent<ItemCollectableBase>();
        if (item != null)
        {
            item.gameObject.AddComponent<Magnetic>();
        }
    }
}

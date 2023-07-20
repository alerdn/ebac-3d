using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour
{
    public int Key => _key;

    [SerializeField] private int _key = 1;
    [SerializeField] private MeshRenderer _renderer;

    private bool _isActive;

    private void Start()
    {
        if (!_isActive) TurnOff();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && !_isActive)
        {
            CheckCheckpoint();
        }
    }

    private void CheckCheckpoint()
    {
        SaveCheckpoint();
        TurnOn();
    }

    private void TurnOn()
    {
        _renderer.material.SetColor("_EmissionColor", Color.white);
    }

    private void TurnOff()
    {
        _renderer.material.SetColor("_EmissionColor", Color.black);
    }

    private void SaveCheckpoint()
    {
        CheckpointManager.Instance.SaveCheckpoint(_key);
        _isActive = true;
    }
}

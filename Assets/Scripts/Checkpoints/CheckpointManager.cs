using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : Singleton<CheckpointManager>
{
    [SerializeField] private List<CheckpointBase> _checkpoints;

    [Header("Debug")]
    [SerializeField] private int _lastCheckpointKey = 0;

    public void SaveCheckpoint(int newCheckpointKey)
    {
        if (newCheckpointKey > _lastCheckpointKey)
        {
            _lastCheckpointKey = newCheckpointKey;
        }
    }

    public Vector3 GetLastCheckpointPosition()
    {
        CheckpointBase cp = _checkpoints.Find(checkpoint => checkpoint.Key == _lastCheckpointKey);
        return cp.transform.position;
    }

    public bool HasCheckpoint()
    {
        return _lastCheckpointKey > 0;
    }
}

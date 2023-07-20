using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : Singleton<CheckpointManager>
{
    [SerializeField] private List<CheckpointBase> _checkpoints;

    [Header("Debug")]
    [SerializeField] private int _lasCheckpointKey = 0;

    public void SaveCheckpoint(int newCheckpointKey)
    {
        if (newCheckpointKey > _lasCheckpointKey)
        {
            _lasCheckpointKey = newCheckpointKey;
        }
    }

    public Vector3 GetLastCheckpointPosition()
    {
        CheckpointBase cp = _checkpoints.Find(checkpoint => checkpoint.Key == _lasCheckpointKey);
        return cp.transform.position;
    }

    public bool HasCheckpoint()
    {
        return _lasCheckpointKey > 0;
    }
}

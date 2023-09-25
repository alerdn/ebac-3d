using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : Singleton<CheckpointManager>
{
    public int LastCheckpointKey => _lastCheckpointKey;
    public int BeforeLastCheckpointKey => _beforeLastCheckpointKey;

    [SerializeField] private List<CheckpointBase> _checkpoints;

    [SerializeField]
    private int _lastCheckpointKey = 0;
    private int _beforeLastCheckpointKey = -1;

    public void SaveCheckpoint(int newCheckpointKey)
    {
        if (newCheckpointKey > _lastCheckpointKey)
        {
            _beforeLastCheckpointKey = _lastCheckpointKey;
            _lastCheckpointKey = newCheckpointKey;
            Notification.Instance.ShowNotification("checkpoint ativado", 2f);
        }
    }

    public Vector3 GetLastCheckpointPosition()
    {
        CheckpointBase cp = _checkpoints.Find(checkpoint => checkpoint.Key == _lastCheckpointKey);
        if (cp != null) return cp.transform.position;
        else return Vector3.zero;
    }

    public bool HasCheckpoint()
    {
        return _lastCheckpointKey > 0;
    }
}

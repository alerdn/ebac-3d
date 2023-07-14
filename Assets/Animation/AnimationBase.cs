using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationType
{
    NONE,
    IDLE,
    RUN,
    DEATH,
    ATTACK
}

public class AnimationBase : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected List<AnimationSetup> _animationSetups;

    public void PlayAnimationByTrigger(AnimationType type)
    {
        AnimationSetup setup = _animationSetups.Find((setup => setup.AnimationType == type));
        if (setup != null)
        {
            _animator.SetTrigger(setup.Trigger);
        }
    }
}

[System.Serializable]
public class AnimationSetup
{
    public AnimationType AnimationType;
    public string Trigger;
}
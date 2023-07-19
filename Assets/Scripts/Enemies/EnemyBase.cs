using DG.Tweening;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IDamageable
{
    [SerializeField] private bool _lookAtPlayer;
    [SerializeField] private AnimationBase _animationBase;
    [SerializeField] private float _startLife = 10f;
    [SerializeField] private FlashColor _flashColor;
    [SerializeField] private ParticleSystem _particles;

    [Header("Start Animation")]
    [SerializeField] private float _startAnimationDuration = .2f;
    [SerializeField] private Ease _startAnimationEase = Ease.OutBack;
    [SerializeField] private bool _startWithBornAnimation = true;

    private float _currentLife;
    private Collider _collider;
    protected Player player;

    private void Awake()
    {
        Init();
        _collider = GetComponent<Collider>();
        player = GameObject.FindObjectOfType<Player>();
    }

    protected virtual void Update()
    {
        if (_lookAtPlayer)
        {
            transform.LookAt(player.transform.position);
        }
    }

    public void OnDamage(float damage)
    {
        if (_flashColor != null) _flashColor.Flash();
        if (_particles != null) _particles.Emit(15);

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }
    }

    #region  Animation

    private void BornAnimation()
    {
        transform.DOScale(0, _startAnimationDuration).SetEase(_startAnimationEase).From();
    }

    public void PlayAnimationByTrigger(AnimationType type)
    {
        _animationBase.PlayAnimationByTrigger(type);
    }

    #endregion

    protected virtual void Init()
    {
        ResetLife();
        if (_startWithBornAnimation) BornAnimation();
    }

    protected virtual void ResetLife()
    {
        _currentLife = _startLife;
    }

    protected virtual void Kill()
    {
        OnKill();
    }

    protected virtual void OnKill()
    {
        _lookAtPlayer = false;
        if (_collider != null) _collider.enabled = false;
        PlayAnimationByTrigger(AnimationType.DEATH);
        Destroy(gameObject, 3f);
    }

    public void Damage(float damage)
    {
        OnDamage(damage);
    }

    public void Damage(float damage, Vector3 direction)
    {
        OnDamage(damage);
        transform.DOMove(transform.position - direction, .1f);
    }

    private void OnCollisionEnter(Collision other)
    {
        Player player = other.transform.GetComponent<Player>();
        if (player != null)
        {
            player.Damage(1f);
        }
    }
}

using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float Speed = 50f;

    [SerializeField] private int _damageAmount = 1;
    [SerializeField] private float _timeToDestroy = 2f;

    private void Awake()
    {
        Destroy(gameObject, _timeToDestroy);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        IDamageable damageable = other.transform.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.Damage(_damageAmount);
            Destroy(gameObject);
        }
    }
}

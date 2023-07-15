using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float Speed = 50f;

    [SerializeField] private List<string> _tagsToHit;
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
        foreach (string tag in _tagsToHit)
        {
            if (other.transform.CompareTag(tag))
            {
                IDamageable damageable = other.transform.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    Vector3 impactDirection = other.transform.position - transform.position;
                    impactDirection = -impactDirection.normalized;
                    impactDirection.y = 0f;

                    damageable.Damage(_damageAmount, impactDirection);
                }

                break;
            }
        }

        if (!other.transform.CompareTag("Projectile")) Destroy(gameObject);
    }
}

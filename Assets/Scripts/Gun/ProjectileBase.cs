using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public int damageAmount = 1;
    public float timeToDestroy = 2f;
    public float speed = 50f;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

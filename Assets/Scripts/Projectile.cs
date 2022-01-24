using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _speed;
    private SphereCollider _colider;
    private void Awake()
    {
        _colider = GetComponent<SphereCollider>();
    }
    private void FixedUpdate()
    {
        MoveProjectile();
    }
    private void OnCollisionEnter(Collision collision)
    {
        var objects = Physics.OverlapSphere(transform.position, _colider.radius, 1 << 8);
        foreach(var i in objects)
        {
            Destroy(i.gameObject);
        }
        gameObject.SetActive(false);
    }

    private void MoveProjectile()
    {
        transform.position = transform.position + Vector3.forward * _speed * Time.fixedDeltaTime;
    }

    public void SetSize(Vector3 size, float radius)
    {
        transform.localScale = size;
        _colider.radius = radius;
    }
}

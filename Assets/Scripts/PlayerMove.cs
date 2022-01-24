using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private Door _door;
    [SerializeField] private PopUp _popUp;
    private SphereCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
    }
    private void FixedUpdate()
    {
        transform.position = transform.position + Vector3.forward * _speed * Time.fixedDeltaTime;

        var hitColliders = Physics.OverlapSphere(transform.position, _collider.radius * 10, 1 << LayerMask.NameToLayer("Door"));
        if (hitColliders.Length > 0)
        {
            _door.OpenDoor();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        _popUp.ShowLosePopUp();
        _speed = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        _popUp.ShowWinPopUp();
        _speed = 0;
    }
}

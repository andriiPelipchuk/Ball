using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 5);
    }
}

using UnityEngine;

public class Door : MonoBehaviour
{
    private Animation _anim;
    private bool _isOpened = false;

    public void OpenDoor()
    {
        if (!_isOpened)
        {
            _anim = GetComponent<Animation>();
            _anim.Play("door");
            _isOpened = true;
        }
    }
}

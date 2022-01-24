using UnityEngine;

public class RouteSize : MonoBehaviour
{
    public void SetSizeRoute(float scaleX)
    {
        transform.localScale = new Vector3(scaleX, 1, 1);
    }
}

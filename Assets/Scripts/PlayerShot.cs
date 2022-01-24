using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private RouteSize routeSize;
    [SerializeField] private PopUp _popUp;
    private float scaleSizeRoute;
    private Vector3 _projectileScale = Vector3.zero;
    private float _radius = 1;

    private void Start()
    {
        scaleSizeRoute = routeSize.gameObject.transform.localScale.x;
    }
    private void Update()
    {
        CheckClick();
    }

    private void CheckClick()
    {
        if (transform.localScale.x <= 0.1f || transform.localScale.y <= 0.1f)
        {
            _popUp.ShowLosePopUp();
            Time.timeScale = 0;
            return;
        }
        var minValuePlayer = 0.05f;
        var minValueProjectile = 0.1f;
        if (Input.GetMouseButton(0))
        {
            transform.localScale -= new Vector3(minValuePlayer, minValuePlayer, minValuePlayer) * Time.deltaTime;
            scaleSizeRoute -= 0.001f * Time.deltaTime;
            routeSize.SetSizeRoute(scaleSizeRoute);
            _radius += 0.2f * Time.deltaTime;
            _projectileScale += new Vector3(minValueProjectile, minValueProjectile, minValueProjectile) * Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SpawnProjectile();
            _radius = 1;
        }
    }

    private void SpawnProjectile()
    {
        var projectile = Instantiate(_projectile.gameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity);
        var variableProjectile = projectile.GetComponent<Projectile>();
        variableProjectile.SetSize(_projectileScale, _radius);
        _projectileScale = Vector3.zero;
    }
}

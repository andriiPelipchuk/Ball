using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private float spawnChance;

    private int xMinScreenPosition = 0, xMaxScreenPosition = 26;
    private int zMinScreenPosition = 0, zMaxScreenPosition = 55;

    private bool _putObstacle;

    private void Start()
    {
        ObstacleGrid();
    }

    public void ObstacleGrid()
    {
        for (float x = xMinScreenPosition; x < xMaxScreenPosition; x+= 0.33f )
        {
            for (float z = zMinScreenPosition; z < zMaxScreenPosition; z+= 0.33f)
            {
                _putObstacle = UnityEngine.Random.value > spawnChance;

                if (_putObstacle) continue;

                var obstacle = Instantiate(_obstacle, new Vector3(x, 0.3f, z), Quaternion.identity);
                obstacle.transform.SetParent(transform);
            }
        }
    }
    
}

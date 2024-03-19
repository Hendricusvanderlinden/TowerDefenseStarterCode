using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public List<GameObject> Path1;
    public List<GameObject> Path2;
    public List<GameObject> Enemies;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SpawnEnemy(int type, Path path)
    {
        var newEnemy = Instantiate(Enemies[type], Path1[0].transform.position, Path1[0].transform.rotation);
        var script = newEnemy.GetComponent<Enemy>();
        script.path = path;
        script.target = Path1[1]; // Set the initial target to the second waypoint of Path1
    }

    private void SpawnTester()
    {
        SpawnEnemy(0, Path.Path1); // Spawn the first enemy type on Path1
    }

    void Start()
    {
        InvokeRepeating("SpawnTester", 1f, 1f);
    }

    public GameObject RequestTarget(Path path, int index)
    {
        List<GameObject> currentPath = path == Path.Path1 ? Path1 : Path2;

        if (index < currentPath.Count - 1)
        {
            return currentPath[index + 1];
        }
        else
        {
            return null; // Reached the end of the path
        }
    }
}

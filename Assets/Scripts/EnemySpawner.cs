using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static EnemySpawner _instance;
    public static EnemySpawner Instance { get { return _instance; } }

    public List<GameObject> Path1;
    public List<GameObject> Path2;
    public List<GameObject> Enemies;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnTester", 1f, 1f);
    }

    private void SpawnTester()
    {
        SpawnEnemy(0, Path.Path1);
    }

    private void SpawnEnemy(int type, Path path)
    {
        var newEnemy = Instantiate(Enemies[type], GetPathList(path)[0].transform.position, Quaternion.identity);
        var script = newEnemy.GetComponent<Enemy>();
        script.path = path;
        script.target = RequestTarget(path, script.GetPathIndex());
    }

    public GameObject RequestTarget(Path path, int index)
    {
        List<GameObject> currentPath = GetPathList(path);

        if (index < currentPath.Count)
        {
            return currentPath[index];
        }
        else
        {
            return null;
        }
    }

    private List<GameObject> GetPathList(Path path)
    {
        switch (path)
        {
            case Path.Path1:
                return Path1;
            case Path.Path2:
                return Path2;
            default:
                return new List<GameObject>();
        }
    }
}

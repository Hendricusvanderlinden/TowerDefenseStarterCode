using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public float health = 10f;
    public int points = 1;

    public Path path { get; set; }
    public GameObject target { get; set; }

    private int pathIndex = 0; 

    public int GetPathIndex()
    {
        return pathIndex;
    }

    public void IncrementPathIndex()
    {
        pathIndex++;
    }

    private void Update()
    {
        MoveAlongPath();
    }

    private void MoveAlongPath()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);

        if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
        {
            IncrementPathIndex();
            target = EnemySpawner.Instance.RequestTarget(path, GetPathIndex());

            if (target == null)
            {
                Destroy(gameObject);
            }
        }
    }
}
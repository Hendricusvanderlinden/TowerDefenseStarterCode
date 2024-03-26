using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public List<GameObject> Path1;
    public List<GameObject> Path2;
    public List<GameObject> Enemies;

    private int ufoCounter = 0;
    private GameManager gameManager;


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
    public void StartWave(int number)
    {
        // Reset de teller
        ufoCounter = 0;

        // Start de gewenste golf op basis van het nummer
        switch (number)
        {
            case 1:
                InvokeRepeating("StartWave1", 1f, 1.5f);
                break;
            // Voeg hier meer gevallen toe voor andere golven indien nodig
            case 2:
                InvokeRepeating("StartWave2", 1f, 1.5f);
                break;
            case 3:
                InvokeRepeating("StartWave3", 1f, 1f);
                break;
            case 4:
                InvokeRepeating("StartWave4", 1f, 1f);
                break;
            case 5:
                InvokeRepeating("StartWave5", 1f, 1f);
                break;
        }
    }

    // Functie om golven van het type 1 te starten
    private void StartWave1()
    {
        SpawnEnemy(0, Path.Path1); // Veronderstel dat type 0 een UFO is, je kunt dit aanpassen aan je eigen logica
        ufoCounter++;

        // Stop de golf na een bepaald aantal UFO's
        if (ufoCounter >= 10) // Veronderstel dat je golf na 10 UFO's moet eindigen, pas dit aan aan je eigen behoeften
        {
            CancelInvoke("StartWave1");
        }
    }

    // Functie om golven van het type 2 te starten
    private void StartWave2()
    {
        if (ufoCounter < 30)
        {
            SpawnEnemy(0, Path.Path1); // Veronderstel dat type 0 een moeilijkere vijand is, je kunt dit aanpassen aan je eigen logica
            ufoCounter++;
        }
        else if (ufoCounter < 40)
        {
            SpawnEnemy(1, Path.Path1); // Veronderstel dat type 1 een nog moeilijkere vijand is, je kunt dit aanpassen aan je eigen logica
            ufoCounter++;
        }
        else if (ufoCounter < 60)
        {
            SpawnEnemy(UnityEngine.Random.Range(0, Enemies.Count), Path.Path1); // Random mix van vijanden
            ufoCounter++;
        }
        else
        {
            CancelInvoke("StartWave2");
        }
    }
    private void StartWave3()
    {
        if (ufoCounter < 50)
        {
            SpawnEnemy(1, Path.Path1); // Veronderstel dat type 1 een moeilijkere vijand is, je kunt dit aanpassen aan je eigen logica
            ufoCounter++;
        }
        else if (ufoCounter < 70)
        {
            SpawnEnemy(2, Path.Path1); // Veronderstel dat type 2 een nog moeilijkere vijand is, je kunt dit aanpassen aan je eigen logica
            ufoCounter++;
        }
        else if (ufoCounter < 90)
        {
            SpawnEnemy(UnityEngine.Random.Range(0, Enemies.Count), Path.Path1); // Random mix van vijanden
            ufoCounter++;
        }
        else
        {
            CancelInvoke("StartWave3");
        }
    }

    // Functie om golven van het type 4 te starten
    private void StartWave4()
    {
        if (ufoCounter < 70)
        {
            SpawnEnemy(2, Path.Path1); // Veronderstel dat type 2 een moeilijkere vijand is, je kunt dit aanpassen aan je eigen logica
            ufoCounter++;
        }
        else if (ufoCounter < 90)
        {
            SpawnEnemy(3, Path.Path1); // Veronderstel dat type 3 een nog moeilijkere vijand is, je kunt dit aanpassen aan je eigen logica
            ufoCounter++;
        }
        else if (ufoCounter < 120)
        {
            SpawnEnemy(UnityEngine.Random.Range(0, Enemies.Count), Path.Path1); // Random mix van vijanden
            ufoCounter++;
        }
        else
        {
            CancelInvoke("StartWave4");
        }
    }

    // Functie om golven van het type 5 te starten
    private void StartWave5()
    {
        if (ufoCounter < 100)
        {
            SpawnEnemy(3, Path.Path1); // Veronderstel dat type 3 een moeilijkere vijand is, je kunt dit aanpassen aan je eigen logica
            ufoCounter++;
        }
        else if (ufoCounter < 130)
        {
            SpawnEnemy(4, Path.Path1); // Veronderstel dat type 4 een nog moeilijkere vijand is, je kunt dit aanpassen aan je eigen logica
            ufoCounter++;
        }
        else if (ufoCounter < 160)
        {
            SpawnEnemy(UnityEngine.Random.Range(0, Enemies.Count), Path.Path1); // Random mix van vijanden
            ufoCounter++;
        }
        else
        {
            CancelInvoke("StartWave5");
        }
    }
}

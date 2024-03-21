using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    // TowerMenu GameObject
    public GameObject TowerMenu;

    // TowerMenu script reference
    private TowerMenu towerMenu;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get TowerMenu script reference
        towerMenu = TowerMenu.GetComponent<TowerMenu>();
    }
}

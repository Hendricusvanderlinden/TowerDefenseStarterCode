using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConstructionSite
{
    public Vector3Int TilePosition { get; private set; }
    public Vector3 WorldPosition { get; private set; }
    public SiteLevel Level { get; private set; }
    public TowerType TowerType { get; private set; }

    private GameObject tower;

    public ConstructionSite(Vector3Int tilePosition, Vector3 worldPosition)
    {
        TilePosition = tilePosition;
        // Aanpassing voor de y-waarde van de wereldpositie
        WorldPosition = new Vector3(worldPosition.x, worldPosition.y + 0.5f, worldPosition.z);

        tower = null;
    }

    public void SetTower(GameObject newTower, SiteLevel newLevel, TowerType newTowerType)
    {
        if (tower != null)
        {
            // Als er al een toren is, verwijder deze
            GameObject.Destroy(tower);
        }

        tower = newTower;
        Level = newLevel;
        TowerType = newTowerType;
    }

    public void RemoveTower()
    {
        if (tower != null)
        {
            // Bereken de verkoopprijs van de toren
            int sellPrice = GameManager.Instance.GetCost(TowerType, Level, true);

            // Voeg de verkoopprijs toe aan de credits van de GameManager
            GameManager.Instance.AddCredits(sellPrice);

            // Vernietig de toren
            GameObject.Destroy(tower);
            tower = null;
        }

        // Reset de level en het type van de bouwplaats
        Level = SiteLevel.Onbebouwd;
        TowerType = default;
    }
}
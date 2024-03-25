using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class TileClickDetector : MonoBehaviour
{
    public Camera cam;
    public Tilemap tilemap;
    public ConstructionSite SelectedSite { get; private set; }
    private List<ConstructionSite> sites = new List<ConstructionSite>();

    private void Start()
    {
        BoundsInt bounds = tilemap.cellBounds;
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                for (int z = bounds.zMin; z < bounds.zMax; z++)
                {
                    Vector3Int cellPosition = new Vector3Int(x, y, z);
                    TileBase foundTile = tilemap.GetTile(cellPosition);
                    if (foundTile != null && foundTile.name == "buildingPlaceGrass")
                    {
                        sites.Add(new ConstructionSite(cellPosition, tilemap.CellToWorld(cellPosition)));
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            DetectTileClicked();
        }
    }

    private void DetectTileClicked()
    {
        if (cam == null || tilemap == null || sites == null)
        {
            Debug.LogError("One or more required components are not initialized.");
            return;
        }

        Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;

        Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);
        cellPosition.z = 0;

        TileBase clickedTile = tilemap.GetTile(cellPosition);

        if (clickedTile != null && clickedTile.name == "buildingPlaceGrass")
        {
            SelectedSite = null;
            foreach (var site in sites)
            {
                if (cellPosition == site.TilePosition)
                {
                    SelectedSite = site;
                    break;
                }
            }
        }
        else
        {
            SelectedSite = null;
        }

        GameManager.Instance.SelectSite(SelectedSite);
    }
}
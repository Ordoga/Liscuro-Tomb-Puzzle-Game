using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetDarkTile : MonoBehaviour
{
    [SerializeField] Tilemap tiles;
    [SerializeField] Tilemap darkTiles;
    [SerializeField] Rigidbody2D handPos;
    [SerializeField] Tile tile;
    public int availablePlatformsNum;
    public Vector3Int location;

    private TileBase getDarkTile;
    private TileBase getMapTile;
    GameManager gameManager;

    void Start()
    {
        availablePlatformsNum = 3;
        gameManager = FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!gameManager.whiteActive) 
        {
            if(Input.GetMouseButtonDown(0) && (availablePlatformsNum > 0))
            {
                PlaceTile();
            }
            if (Input.GetMouseButtonDown(1))
            {
                RemoveTile();
            }

        }
    }

    private void PlaceTile()
    {
        location = tiles.WorldToCell(handPos.position);
        getDarkTile = darkTiles.GetTile(location);
        getMapTile = tiles.GetTile(location);


        if (!getMapTile && !getDarkTile)
        {
            darkTiles.SetTile(location, tile);
            availablePlatformsNum -= 1;
        }
    }

    private void RemoveTile()
    {
        location = tiles.WorldToCell(handPos.position);
        getDarkTile = darkTiles.GetTile(location);
        getMapTile = tiles.GetTile(location);

        if (getDarkTile && !getMapTile)
        {
            darkTiles.SetTile(location, null);
            availablePlatformsNum += 1;
        }
    }

}

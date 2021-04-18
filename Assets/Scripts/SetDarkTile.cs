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
    private Vector3Int location;

    private TileBase getDarkTile;
    private TileBase getMapTile;
    GameManager gameManager;

    [SerializeField] Sprite redHand;
    [SerializeField] Sprite RegularHand;
    [SerializeField] SpriteRenderer darkSpriteRenderer;
    void Start()
    {
      
        //availablePlatformsNum = 3;
        gameManager = FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!gameManager.whiteActive) 
        {
            location = tiles.WorldToCell(handPos.position);
            getDarkTile = darkTiles.GetTile(location);
            getMapTile = tiles.GetTile(location);

            darkSpriteRenderer.sprite = RegularHand;

            if(getDarkTile || getMapTile) // Changes dark rect hand color to red if detect a tile 
            {
                darkSpriteRenderer.sprite = redHand;
            }

            if (Input.GetMouseButtonDown(0) && (availablePlatformsNum > 0))
            {
                PlaceTile(location, getDarkTile, getMapTile);
            }
            if (Input.GetMouseButtonDown(1))
            {
                RemoveTile(location, getDarkTile, getMapTile);
            }

        }
    }

    private void PlaceTile(Vector3Int location, TileBase getDarkTile, TileBase getMapTile)
    {

        if (!getMapTile && !getDarkTile)
        {
            
            darkTiles.SetTile(location, tile);
            availablePlatformsNum -= 1;
        }
    }

    private void RemoveTile(Vector3Int location, TileBase getDarkTile, TileBase getMapTile)
    {

        if (getDarkTile && !getMapTile)
        {
            darkTiles.SetTile(location, null);
            availablePlatformsNum += 1;
        }
    }
   // private void changeHandToRed()

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildSystem : MonoBehaviour
{
    [SerializeField] Tilemap tiles;
    [SerializeField] Tilemap darkTiles;
    [SerializeField] Rigidbody2D handPos;
    [SerializeField] Tile tile;
    [SerializeField] Sprite redHand;
    [SerializeField] Sprite RegularHand;

    public int availablePlatformsNum;

    Vector3Int location;
    TileBase getDarkTile;
    TileBase getMapTile;
    GameManager gameManager;
    SpriteRenderer darkSpriteRenderer;
    void Start()
    {
        //availablePlatformsNum = 3;
        gameManager = FindObjectOfType<GameManager>();
        darkSpriteRenderer = GetComponentInParent<SpriteRenderer>();
    }
    
    void Update()
    {
        if (!gameManager.whiteActive) 
        {
            location = tiles.WorldToCell(handPos.position);
            getDarkTile = darkTiles.GetTile(location);
            getMapTile = tiles.GetTile(location);

            darkSpriteRenderer.sprite = RegularHand;

            if(getDarkTile || getMapTile) // Changes dark rect hand color to red if any tile is detected 
            {
                darkSpriteRenderer.sprite = redHand;
            }

            if (Input.GetMouseButtonDown(0))
            { 
                if(availablePlatformsNum > 0 && !getMapTile && !getDarkTile) //if tile location available
                {
                    PlaceTile(location);
                }
                else
                {
                    if(getDarkTile && !getMapTile)      //if tile location occupied by dark tile
                    {
                        RemoveTile(location);
                    }
                }
            }
        }
    }

    private void PlaceTile(Vector3Int location)
    {
   
        darkTiles.SetTile(location, tile);
        availablePlatformsNum --;

    }

    private void RemoveTile(Vector3Int location)
    {

        darkTiles.SetTile(location, null);
        availablePlatformsNum ++;
    }

}

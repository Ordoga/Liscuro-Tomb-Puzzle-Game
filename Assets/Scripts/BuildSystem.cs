using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildSystem : MonoBehaviour
{
    [SerializeField] Tilemap tiles;
    [SerializeField] Tilemap darkTiles;
    [SerializeField] Tilemap placeTiles;
    [SerializeField] Rigidbody2D handPos;
    [SerializeField] Tile tile;
    [SerializeField] Sprite redHand;
    [SerializeField] Sprite RegularHand;
    //[SerializeField] Grid grid;

    public int availablePlatformsNum;

    

    Vector3Int HandLocation;
    //Vector3Int whiteRectPos;
    //TileBase getWhiteRectTile;
    TileBase getPlaceTile;
    TileBase getDarkTile;
    TileBase getMapTile;

    //two tileBases under placeTile tileMap
    [SerializeField] TileBase GreenTile;
    [SerializeField] TileBase invisibleTile;

    GameManager gameManager;
    SpriteRenderer darkSpriteRenderer;

    Color activateColor = new Color(0.0f, 255.0f, 0.0f, 255.0f*0.8f);
    Color deactivateColor = new Color(0.0f, 255.0f, 0.0f, 0.0f);

    Vector3Int currGreenPos;

    bool menuDisplay;

    void Start()
    {
        availablePlatformsNum = 3;
        menuDisplay = false;

        currGreenPos = HandLocation;
        gameManager = FindObjectOfType<GameManager>();
        darkSpriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
        
        if (!gameManager.whiteActive) 
        {
           // Vector3Int WhiteRect = grid.WorldToCell(GameObject.Find("White Rect").transform.position);

            HandLocation = tiles.WorldToCell(handPos.position);
            
            // getWhiteRectTile = tiles.GetTile(whiteRectLocation);

            getPlaceTile = placeTiles.GetTile(HandLocation);
            getDarkTile = darkTiles.GetTile(HandLocation);
            getMapTile = tiles.GetTile(HandLocation);

            darkSpriteRenderer.sprite = RegularHand;

            //if(getDarkTile || getMapTile) // Changes dark rect hand color to red if any tile is detected 

            if(!getPlaceTile) //Changes dark rect hand color to red if hand is not ReadOnlyCollectionBase place tile
            {
                darkSpriteRenderer.sprite = redHand;
                placeTiles.SetTile(currGreenPos, invisibleTile);
                currGreenPos = HandLocation;
            }
            if (Input.GetMouseButtonDown(1))
            {
                menuDisplay = !menuDisplay;
            }

            if (menuDisplay) //if menu is on
            {
                if (availablePlatformsNum > 0 && getPlaceTile ) //if theres are enought tiles and can place
                {
                    placeTiles.SetTile(HandLocation, GreenTile);

                    if (placeTiles.GetTile(currGreenPos) != getPlaceTile) //if hand position is no longer on the last green tile cell-change the green pos
                    {

                        placeTiles.SetTile(HandLocation, GreenTile);
                        placeTiles.SetTile(currGreenPos, invisibleTile);
                        currGreenPos = HandLocation;
                    }

                    if (Input.GetMouseButtonDown(0) && placeTiles.GetTile(currGreenPos) == getPlaceTile)//if deciding to place a dark tile and hand pos is on green tile
                    {
                        PlaceTile(HandLocation);
                        menuDisplay = false;

                        

                    }                  
                    
                }

            }
            else if (!menuDisplay)//if not on menu- remove the last green tile shown
            {
                placeTiles.SetTile(currGreenPos, invisibleTile);
                currGreenPos.Set(100, 100, 100);
            }
            
            
            if(getDarkTile && Input.GetMouseButtonDown(0))      //if tile location occupied by dark tile
            {
                RemoveTile(HandLocation);
                menuDisplay = false;
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


    /*private void SetTileColourGreen(Vector3Int position)
    {

        placeTiles.SetTile(position, GreenTile);
        getTile = tilemap.GetTile(position);
        return getTile;
    }*/

}

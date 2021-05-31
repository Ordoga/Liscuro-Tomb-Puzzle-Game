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
    [SerializeField] AudioSource buildSound;
    [SerializeField] AudioSource breakSound;

    public int availablePlatformsNum;

    Vector3Int handLocation;
    TileBase getPlaceTile;
    TileBase getDarkTile;

    //two tileBases under placeTile tileMap
    [SerializeField] TileBase GreenTile;
    [SerializeField] TileBase invisibleTile;

    GameManager gameManager;
    SpriteRenderer darkSpriteRenderer;
    Vector3Int currGreenPos;

    void Start()
    {
        currGreenPos = handLocation;
        gameManager = FindObjectOfType<GameManager>();
        darkSpriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    void Update()
    {
        
        if (!gameManager.whiteActive) 
        {
            //Collect info on hand location and any Daek or Placement tiles in the spot
            handLocation = tiles.WorldToCell(handPos.position);
            getPlaceTile = placeTiles.GetTile(handLocation);
            getDarkTile = darkTiles.GetTile(handLocation);

            
            if (!getPlaceTile) //If no Placement tile is build, building is disabled
            {
                darkSpriteRenderer.sprite = redHand;

                if (Input.GetMouseButtonDown(0) && availablePlatformsNum > 0)
                {
                    currGreenPos = handLocation;
                }
                if (Input.GetMouseButton(0) && availablePlatformsNum > 0 && placeTiles.GetTile(currGreenPos) != placeTiles.GetTile(handLocation)) //if theres are enought tiles and can place
                {
                    SetInvisiTile(currGreenPos);
                    currGreenPos = handLocation;
                }
            }
            else // Building is enabled
            {
                if (getDarkTile)
                {
                    darkSpriteRenderer.sprite = redHand;
                }
                else
                {
                    darkSpriteRenderer.sprite = RegularHand;
                }

                //Only if player presses mouse key the build event begins. It is divided into 3 steps: click down, hold and release
                if (Input.GetMouseButtonDown(0) && availablePlatformsNum > 0) //Click down - initialize green placement tile
                {
                    SetGreenTile(handLocation);
                    currGreenPos = handLocation;
                }
                if (Input.GetMouseButton(0) && availablePlatformsNum > 0 && placeTiles.GetTile(currGreenPos) != placeTiles.GetTile(handLocation)) //Hold - Only occurs if tiles are available, updates the green placement tile
                {
                    SetGreenTile(handLocation);
                    SetInvisiTile(currGreenPos);
                    currGreenPos = handLocation;
                }

                if (Input.GetMouseButtonUp(0))// Release - performs the action: remove or set dark tile
                {
                    SetInvisiTile(currGreenPos);
                    currGreenPos = handLocation;
                    if (!getDarkTile)
                    {
                        if (availablePlatformsNum > 0)
                        {
                            PlaceDarkTile(handLocation);
                        }
                    }
                    else
                    {
                        RemoveDarkTile(handLocation);
                    }

                }
            }
        }
    }

    private void PlaceDarkTile(Vector3Int location)
    {
   
        darkTiles.SetTile(location, tile);
        availablePlatformsNum --;
        buildSound.Play(0);

    }

    private void RemoveDarkTile(Vector3Int location)
    {

        darkTiles.SetTile(location, null);
        availablePlatformsNum ++;
        breakSound.Play(0);
    }

    private void SetGreenTile(Vector3Int position)
    {
        placeTiles.SetTile(position, GreenTile);
    }

    private void SetInvisiTile(Vector3Int position)
    {
        placeTiles.SetTile(position, invisibleTile);
    }

}

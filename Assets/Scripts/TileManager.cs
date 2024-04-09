using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;


public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;


    [SerializeField] private Tile plowedTile;
    [SerializeField] private Tile wateredTile;


    [SerializeField] private Tilemap cropMap;
    [SerializeField] private Tile weathTile;

    
    void Start()
    {
        InitializeTilemaps();
    }
    void InitializeTilemaps()
    {
        InitializeTilemap(interactableMap);
        InitializeTilemap(cropMap);
    }
    void InitializeTilemap(Tilemap tilemap)
    {
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(position);
            if (tile != null && tile.name == "Interactable_Visible")
            {
                tilemap.SetTile(position, hiddenInteractableTile);
            }
        }
    }
    public void SetPlowed(Vector3Int position)
    {
        interactableMap.SetTile(position, plowedTile);
    }
    public void SetWatered(Vector3Int position)
    {
        interactableMap.SetTile(position, wateredTile);
    }

    public string GetTileName(Vector3Int position)
    {
        if (interactableMap != null)
        {
            TileBase tile = interactableMap.GetTile(position);

            if (tile != null)
            {
                return tile.name;
            }
        }
        return "";
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
//using UnityEngine.WSA;


public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;


    [SerializeField] private Tile plowedTile;
    [SerializeField] private Tile wateredTile;
    [SerializeField] private Tile wheatTile1;
    [SerializeField] private Tile wheatTile2;
    [SerializeField] private Tile wheatTile3;
    [SerializeField] private Tile wheatTile4;

    [SerializeField] private Tilemap cropMap;

    [SerializeField] public Item Wheat_Item;

    private Dictionary<Vector3Int, int> wheatPositions = new Dictionary<Vector3Int, int>();
    private Dictionary<Vector3Int, int> wheatGrowthStages = new Dictionary<Vector3Int, int>();
    private Dictionary<Vector3Int, float> wheatGrowthTimers = new Dictionary<Vector3Int, float>();
    private Dictionary<Vector3Int, Coroutine> growthCoroutines = new Dictionary<Vector3Int, Coroutine>();

    public Player player;

    void Start()
    {
        player = GetComponent<Player>();
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
    public void PlantWheat(Vector3Int position)
    {
        // Set the initial growth stage for the planted wheat
        cropMap.SetTile(position, wheatTile1);

        // Start the growth coroutine for the planted wheat
        Coroutine growthCoroutine = StartCoroutine(GrowWheat(position));
        growthCoroutines.Add(position, growthCoroutine);
    }


    IEnumerator GrowWheat(Vector3Int position)
    {
        float growthTime1 = Random.Range(5, 10);
        float growthTime2 = Random.Range(5, 10);
        float growthTime3 = Random.Range(5, 10);

        yield return new WaitForSeconds(growthTime1);
        cropMap.SetTile(position, wheatTile2);

        yield return new WaitForSeconds(growthTime2);
        cropMap.SetTile(position, wheatTile3);

        yield return new WaitForSeconds(growthTime3);
        cropMap.SetTile(position, wheatTile4);

        // Remove the growth coroutine from the dictionary when growth is complete
        growthCoroutines.Remove(position);
    }

   
    public void ClearTile(Vector3Int position)
    {
        interactableMap.SetTile(position, plowedTile);
        cropMap.SetTile(position, null);
        if (wheatPositions.ContainsKey(position))
        {
            wheatPositions.Remove(position);
            
        }
        

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
    public string GetPlantName(Vector3Int position)
    {
        if (cropMap != null)
        {
            TileBase tile = cropMap.GetTile(position);

            if (tile != null)
            {
                return tile.name;
            }
        }
        return "";
    }

}

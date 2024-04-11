using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    private Crop crop;
    public InventoryManager inventoryManager;
    private TileManager tileManager;
    public Item WheatItem;

    

    private void Awake()
    {
        crop = GetComponent<Crop>();
        tileManager = GameManager.instance.tileManager;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tileManager != null)
            {
                Vector3Int position = new Vector3Int((int)transform.position.x,
                    (int)transform.position.y, 0);

                string tileName = tileManager.GetTileName(position);
                string cropName = tileManager.GetPlantName(position);


                if (!string.IsNullOrWhiteSpace(tileName))
                {
                    if (tileName == "Interactable" && inventoryManager.toolbar.selectedSlot.itemName == "Hoe")
                    {
                        tileManager.SetPlowed(position);
                    }
                    else if (tileName == "Plowed" && inventoryManager.toolbar.selectedSlot.itemName == "Watering Can")
                    {
                        tileManager.SetWatered(position);
                        
                    }
                    else if (tileName == "Plowed_Water" && cropName != "Wheat_1" && cropName != "Wheat_2" && cropName != "Wheat_3" && cropName != "Wheat_4")
                    {
                        PlantCrop(position);
                    }
                    else if (inventoryManager.toolbar.selectedSlot.itemName == "Sythe" && cropName == "Wheat_4")
                    {
                        int rnd = Random.Range(1, 3);
                        DropItem2(WheatItem, rnd);
                        tileManager.ClearTile(position);
                        
                    }
                }
            }
        }
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 1.5f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset,
            Quaternion.identity);
        droppedItem.rb2d.AddForce(spawnOffset * 1f, ForceMode2D.Impulse);
    }
    public void DropItem2(Item item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 1.1f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset,
            Quaternion.identity);
        droppedItem.rb2d1.AddForce(spawnOffset * 1f, ForceMode2D.Impulse);
    }


    public void DropItem(Item item, int numToDop)
    {
        for (int i = 0; i < numToDop; i++)
        {
            DropItem(item);
        }
    } public void DropItem2(Item item, int numToDop)
    {
        for (int i = 0; i < numToDop; i++)
        {
            DropItem2(item);
        }
    }

    public void PlantCrop(Vector3Int position)
    {
        // Get the name of the selected seed from the toolbar
        string selectedSeed = inventoryManager.toolbar.selectedSlot.itemName;
        
        // Check the selected seed and perform the corresponding action
        switch (inventoryManager.toolbar.selectedSlot.itemName)
        {
            case "Wheat_Seed":
                tileManager.PlantWheat(position);
                break;
                
        }
    }
}

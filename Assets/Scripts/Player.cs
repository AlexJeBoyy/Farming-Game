using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private TileManager tileManager;
    private void Awake()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }
    private void Start()
    {
         tileManager= GameManager.instance.tileManager;
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
    public void DropItem(Item item, int numToDop)
    {
        for(int i = 0; i < numToDop; i++)
        {
            DropItem(item);
        }
    }
}

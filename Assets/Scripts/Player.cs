using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryManager inventory;
    


    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x,
                (int)transform.position.y, 0);

            if (GameManager.instance.tileManager.IsInteractable(position))
            {
                GameManager.instance.tileManager.SetInteracted(position);
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

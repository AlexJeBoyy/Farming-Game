using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Dictionary<string, Inventory_UI> inventoryUIByName = new Dictionary<string, Inventory_UI>();

    public List<Inventory_UI> inventoryUIs;

    public GameObject inventoryPanel;
    public GameObject menu;


    public static Slot_UI draggedSlot;
    public static Image draggedIcon;
    public static bool dragSingle;
    private void Start()
    {
        
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }

        if (menu != null)
        {
            menu.SetActive(false);
        }


    }
    private void Awake()
    {
        Initialize();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
            menu.SetActive(false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            dragSingle = true;
        }
        else
        {
            dragSingle = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
            //Time.timeScale = 1;
            inventoryPanel.SetActive(false);
        }
    }
    public void ToggleMenu()
    {
        if (menu != null)
        {
            if (!menu.activeSelf)
            {

                Time.timeScale = 0;
                menu.SetActive(true);
                //RefreshInventoryUI("Backpack");
            }
            else
            {
                Time.timeScale = 1;
                menu.SetActive(false);
            }
        }
    }
    public void ToggleInventory()
    {
        if (inventoryPanel != null)
        {
            if (!inventoryPanel.activeSelf)
            {

                Time.timeScale = 0;
                inventoryPanel.SetActive(true);
                RefreshInventoryUI("Backpack");
            }
            else
            {
                Time.timeScale = 1;
                inventoryPanel.SetActive(false);
            }
        }
    }
    public void RefreshInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName) && inventoryUIByName[inventoryName] != null)
        {
            inventoryUIByName[inventoryName].Refresh();
        }
    }
    public void RefreshAll()
    {
        foreach (KeyValuePair<string, Inventory_UI> keyValuePair in inventoryUIByName)
        {
            keyValuePair.Value.Refresh();
        }
    }
    public Inventory_UI GetInventory(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            return inventoryUIByName[inventoryName];
        }
        return null;
    }

    private void Initialize()
    {
        foreach (Inventory_UI ui in inventoryUIs)
        {
            if (!inventoryUIByName.ContainsKey(ui.inventoryName))
            {
                inventoryUIByName.Add(ui.inventoryName, ui);
            }
        }
    }
}

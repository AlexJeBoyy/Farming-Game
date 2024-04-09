using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    public ItemManager itemManager;
    public TileManager tileManager;
    public UI_Manager uiManager;

    public Player player;

    public int curDay;
    public int money;
    public int cropInventory;
    public CropData selectedCropToPlant;
    public event UnityAction onNewDay;

    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        itemManager = FindObjectOfType<ItemManager>();
        tileManager = FindObjectOfType<TileManager>();
        uiManager = FindObjectOfType<UI_Manager>();

        player = FindObjectOfType<Player>();
    }

    void OnEnable()
    {
        Crop.onPlantCrop += OnPlantCrop;
        Crop.onHarvestCrop += OnHarvestCrop;
    }
    void OnDisable()
    {
        Crop.onPlantCrop -= OnPlantCrop;
        Crop.onHarvestCrop -= OnHarvestCrop;
    }

    // Called when a crop has been planted.
    // Listening to the Crop.onPlantCrop event.
    public void OnPlantCrop(CropData cop)
    {
        cropInventory--;
    }
    // Called when a crop has been harvested.
    // Listening to the Crop.onCropHarvest event.
    public void OnHarvestCrop(CropData crop)
    {
        money += crop.sellPrice;
    }
    // Called when we want to purchase a crop.
    public void PurchaseCrop(CropData crop)
    {
    }
    // Do we have enough crops to plant?
    
    // Called when the buy crop button is pressed.
    public void OnBuyCropButton(CropData crop)
    {
    }
}

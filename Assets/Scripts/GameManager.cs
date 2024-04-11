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
    //public event UnityAction onNewDay;

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

   
    
}

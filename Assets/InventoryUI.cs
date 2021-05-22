

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;
    public GameObject[] Slots;
    
  
    void Awake()
    {

        // if the singleton hasn't been initialized yet
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void InventorySlot()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            Slots[i].SetActive(true);
          
        }
    }
}

using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

class InventoryControl : MonoBehaviour
{
    public static InventoryControl inventoryControl;
    public List<InventoryObject> inventoryObjects;

    string filePath = "/playerInventory.dat";

    private void Awake()
    {
        if (inventoryControl == null)
        {
            inventoryControl = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (inventoryControl != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnGUI()
    {

    }

    public void Save()
    {
        print("Saved to " + Application.persistentDataPath + filePath);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + filePath);

        foreach (var item in inventoryObjects)
        {
            bf.Serialize(file, item);
        }

        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + filePath, FileMode.Open);
            
            file.Close();

            
        }
    }


}
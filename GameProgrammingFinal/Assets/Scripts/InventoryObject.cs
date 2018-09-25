using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
class InventoryObject
{
    public string itemName = "New Item";
    public GameObject model = null;
    public Texture2D itemIcon = null;
    public Rigidbody itemRigidbody = null;
}
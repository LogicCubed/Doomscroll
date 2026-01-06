using UnityEngine;

[System.Serializable]
public class ShopItem
{
    public string itemName;
    public int cost;
    public int owned;
    public int productionPerUnit = 1;
    public float productionInterval = 5f;

    [HideInInspector] public float timer;
}
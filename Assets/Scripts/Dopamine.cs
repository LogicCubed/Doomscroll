using TMPro;
using UnityEngine;

public class Dopamine : MonoBehaviour
{
    public int dopamineCount = 0;

    [Header("UI")]
    public TextMeshProUGUI dopamineCounter;

    void Update()
    {
        UpdateDopamineCount();
    }

    public void AddDopamine(int amount)
    {
        dopamineCount += amount;
    }

    public void RemoveDopamine(int amount)
    {
        dopamineCount -= amount;
    }

    private void UpdateDopamineCount()
    {
        if (dopamineCounter != null)
            dopamineCounter.text = "Dopamine: " + dopamineCount;
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReelManager : MonoBehaviour
{
    [Header("References")]
    public RectTransform reelContainer;
    public GameObject reelPrefab;

    [Header("Settings")]
    public float reelHeight = 820f;
    public Vector2 spawnPosition = new Vector2(0, -1230f);
    public Dopamine dopamineManager;

    public void OnScrollNext()
    {
        SpawnReel();

        if (dopamineManager != null)
        {
            dopamineManager.AddDopamine(1);
        }

    }

    private void SpawnReel()
    {
        if (reelPrefab == null || reelContainer.childCount == 0) return;

        // Find the bottom-most reel
        RectTransform bottomReel = reelContainer.GetChild(reelContainer.childCount - 1) as RectTransform;

        // Instantiate new reel
        GameObject newReel = Instantiate(reelPrefab, reelContainer);
        RectTransform rt = newReel.GetComponent<RectTransform>();

        // Set pivot & anchors
        rt.anchorMin = new Vector2(0.5f, 1);
        rt.anchorMax = new Vector2(0.5f, 1);
        rt.pivot = new Vector2(0.5f, 1);

        // Position new reel directly below the bottom reel
        rt.anchoredPosition = new Vector2(0, bottomReel.anchoredPosition.y - reelHeight);

        // Assign random color for now
        Image img = newReel.GetComponentInChildren<Image>();
        if (img != null)
        {
            img.color = new Color(Random.value, Random.value, Random.value);
        }
    }

}
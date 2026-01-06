using UnityEngine;

public class Scroll : MonoBehaviour
{
    [Header("UI References")]
    public RectTransform screenMask;
    public RectTransform reelContainer;

    public ReelManager reelManager;

    [Header("Settings")]
    public float scrollSpeed = 5000f;

    private bool isScrolling = false;     
    private int currentIndex = 0;         

    void Update()
    {
        HandleScrollInput();
        
    }

    private void HandleScrollInput()
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(screenMask, Input.mousePosition))
            return;

        float scroll = Input.mouseScrollDelta.y;
        if (scroll < 0f && !isScrolling)
        {
            currentIndex++;
            currentIndex = Mathf.Clamp(currentIndex, 0, reelContainer.childCount - 1);
            StartCoroutine(ScrollToReel(currentIndex));
        }
    }

    private System.Collections.IEnumerator ScrollToReel(int reelIndex)
    {
        isScrolling = true;

        RectTransform nextReel = reelContainer.GetChild(reelIndex) as RectTransform;
        Vector2 endPos = new Vector2(0, -nextReel.anchoredPosition.y);

        while ((reelContainer.anchoredPosition - endPos).sqrMagnitude > 0.01f)
        {
            reelContainer.anchoredPosition = Vector2.MoveTowards(
                reelContainer.anchoredPosition,
                endPos,
                scrollSpeed * Time.deltaTime
            );
            yield return null;
        }

        reelContainer.anchoredPosition = endPos;
        isScrolling = false;

        if (reelManager != null)
            reelManager.OnScrollNext();
    }
}
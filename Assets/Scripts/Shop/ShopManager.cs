using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("References")]
    public Dopamine dopamine;

    [Header("Items")]
    public ShopItem maxwell;

    private void Update()
    {
        HandleMaxwellProduction();
    }

    private void HandleMaxwellProduction()
    {
        if (maxwell == null || maxwell.owned <= 0)
            return;

        maxwell.timer += Time.deltaTime;

        if (maxwell.timer >= maxwell.productionInterval)
        {
            int produced = maxwell.owned * maxwell.productionPerUnit;
            dopamine.AddDopamine(produced);
            maxwell.timer = 0f;
        }
    }

    public void BuyMaxwell()
    {
        if (maxwell == null || dopamine == null)
            return;

        if (dopamine.dopamineCount < maxwell.cost)
            return;

        dopamine.RemoveDopamine(maxwell.cost);
        maxwell.owned++;

        Debug.Log($"Bought Maxwell. Owned: {maxwell.owned}");
    }
}
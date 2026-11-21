using UnityEngine;


public class PassiveIncome : MonoBehaviour
{
    [SerializeField] private EconomyManager ecoManager;

    private void Update()
    {
        if (ecoManager == null)
        {
            return;
        }

        for (int i = 0; i < EconomyManager.CurrencyCount; ++i)
        {
            CurrencyType currency = (CurrencyType)i;
            double perSecond = ecoManager.GetPerSecond(currency);

            if (perSecond > 0)
            {
                ecoManager.Add(currency, perSecond * Time.deltaTime);
            }
        }
    }
}

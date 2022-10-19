using UnityEngine;
using UnityEngine.UI;

public class HireMenu : MonoBehaviour
{
    public int TierOneCost = 400;
    public int TierTwoCost = 1200;
    public int TierThreeCost = 2000;

    public PlayerHQ player;

    [Header("Buttons")]
    public Button TierOneButton;
    public Button TierTwoButton;
    public Button TierThreeButton;

    public Text CombatPowerNR;

    public void OnEnable()
    {
        CashCheck();
    }
    private void Update()
    {
        UpdateCP();
    }

    void UpdateCP()
    {
        CombatPowerNR.text = player.CombatPower.ToString();
    }

    public void HireTireOne()
    {
        player.HireTierOne();
        Resources.Instance.Spend(TierOneCost);
        CashCheck();
    }

    public void HireTierTwo()
    {
        player.HireTierTwo();
        Resources.Instance.Spend(TierTwoCost);
        CashCheck();
    }

    public void HireTierThree()
    {
        player.HireTierThree();
        Resources.Instance.Spend(TierThreeCost);
        CashCheck();
    }

    void CashCheck()
    {
        if (Resources.Instance.PlayerCash >= TierOneCost)
        {
            TierOneButton.interactable = true;
        }
        else
            TierOneButton.interactable = false;

        if (Resources.Instance.PlayerCash >= TierTwoCost)
        {
            TierTwoButton.interactable = true;
        }
        else
            TierTwoButton.interactable = false;

        if (Resources.Instance.PlayerCash >= TierThreeCost)
        {
            TierThreeButton.interactable = true;
        }
        else
            TierThreeButton.interactable = false;
    }
}

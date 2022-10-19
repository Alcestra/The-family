using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{

    [Header("Building names")]
    public Text BreweryName;
    public Text PubName;

    [Header("Pricing")]
    public int PubBuyingPrice = 1500;
    public int BreweryBuyingPrice = 1500;

    [Header("Buttons")]
    public Button buyPubButton;
    public Button buyBreweryButton;
    public Button cantAffordButton;

    public GameObject winScreen;
    public UI_Interaction UI_Interaction;
    public Building activeBuilding;
    public WinCondition wincond;


    public void OnEnable()
    {
        CashCheck();
        if(activeBuilding.playerOwned == false)
        {
            activeBuilding.playerOwned = true;
            wincond.AcquiredBuilding();
        }
    }

  public void OpenWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void BuyPub()
    {
        CashCheck();
        Resources.Instance.PlayerCash -= 1500;
        activeBuilding.gameObject.GetComponent<Bar>().enabled = true;
        UI_Interaction.Combat_UI.SetActive(false);
        UI_Interaction.activeUI = false;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }


    public void BuyBrewery()
    {
        CashCheck();
        Resources.Instance.PlayerCash -= 1500;
        activeBuilding.gameObject.GetComponent<Brewery>().enabled = true;
        UI_Interaction.Combat_UI.SetActive(false);
        UI_Interaction.activeUI = false;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void CantAfford()
    {
        UI_Interaction.closeWinMenu();
    }


    public void CashCheck()
    {
        if(Resources.Instance.PlayerCash >= PubBuyingPrice)
        {
            buyPubButton.interactable = true;
        }
        else 
            buyPubButton.interactable = false;

        if(Resources.Instance.PlayerCash >= BreweryBuyingPrice)
        {
           buyBreweryButton.interactable = true;
        }
        else
            buyBreweryButton.interactable = false;
    }
}

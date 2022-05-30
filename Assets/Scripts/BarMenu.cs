using UnityEngine;
using UnityEngine.UI;

public class BarMenu : MonoBehaviour
{
   // is effectivly just a display

    //the pub that has the menu info
    public Bar CurrentPub;

    //names and other over laying info
    #region Names
    [Header("Naming and sizes")]
    public Text PubName;
    public Text PubSize;
    public Text PubType;
    #endregion


    //numerical values for cost and upkeep of building
    #region info
    [Header("building expenses and earnings")]
    public Text pubUpkeep;
    public Text pubEarning;
    public Text pubConsumption;
    public Text pubPoliceActivity;

    [Header("Upgrade lvls")]
    public Text pubSecurity;
    public Text pubDeflect;
    public Text pubAmbiance;
    public Text pubWordOfMouth;

    [Header("Upgrade Costs")]
    public Text pubSecUpgradeCost;
    public Text pubDefUpgradeCost;
    public Text pubAmbiCost;
    public Text pubWOMCost;
    #endregion

    [Header("Buttons")]
    public Button SecUpgradeButton;
    public Button DefUpgradeButton;
    public Button AmbiUpgradeButton;
    public Button WOMUpgradeButton;

    private void Update()
    {
        RacketInfoUpdate();        
    }

    public void Open(Bar currentPub)
    {
        CurrentPub = currentPub;
        RacketInfoUpdate();
        LVLCHECKSec();
        LVLCHeckDEF();
        LVLCheckAmbi();
        LVLCheckWOM();
    }

    public void CloseUI()
    {
        CurrentPub = null;
    }

    #region Buttons for upgrading
    public void ButtonUpgradeSec()
    {
        if(CurrentPub.pubSecurity < 5 && Resources.Instance.SpendCheck(CurrentPub.pubSecUpgradeCost))
        {
            CurrentPub.UpgradeSEC();
            LVLCHECKSec();
        }
        
    }
    public void ButtonUpgradeDef()
    {
        if(CurrentPub.pubDeflect < 5 && Resources.Instance.SpendCheck(CurrentPub.pubDefUpgradeCost))
        {
            CurrentPub.UpgradeDef();
            LVLCHeckDEF();
        }
    }
    
    public void ButtonUpgradeAmbi()
    {
        if(CurrentPub.pubAmbiance < 5 && Resources.Instance.SpendCheck(CurrentPub.pubAmbiUpgradeCost))
        {
            CurrentPub.UpgradeAmbi();
            LVLCheckAmbi();
        }
    }

    public void ButtonUpgradeWOM()
    {
        if(CurrentPub.pubWordOfMouth < 5 && Resources.Instance.SpendCheck(CurrentPub.pubWOMCost))
        {
            CurrentPub.UpgradeWOM();
            LVLCheckWOM();
        }
    }
    #endregion

    #region Buttons set interactive 
    void LVLCHECKSec()
    {
        if (CurrentPub.pubSecurity < 5 && Resources.Instance.PlayerCash >= CurrentPub.pubSecUpgradeCost)
        {
            SecUpgradeButton.interactable = true;
        }
        else
            SecUpgradeButton.interactable = false;
    }

    void LVLCHeckDEF()
    {
        if (CurrentPub.pubDeflect < 5 && Resources.Instance.PlayerCash >= CurrentPub.pubDefUpgradeCost)
        {
            DefUpgradeButton.interactable = true;
        }
        else
            DefUpgradeButton.interactable = false;
    }
     void LVLCheckAmbi()
    {
        if (CurrentPub.pubAmbiance < 5 && Resources.Instance.PlayerCash >= CurrentPub.pubAmbiUpgradeCost)
        {
            AmbiUpgradeButton.interactable = true;
        }
        else
            AmbiUpgradeButton.interactable = false;
    }
    private void LVLCheckWOM()
    {
       if(CurrentPub.pubWordOfMouth < 5 && Resources.Instance.PlayerCash >= CurrentPub.pubWOMCost)
        {
            WOMUpgradeButton.interactable = true;
        }
       else
            WOMUpgradeButton.interactable = false;
    }
    #endregion

    #region RacketInfo
    public void RacketInfoUpdate()
    {
        //building size/name and type
        PubName.text = CurrentPub.RacketName;
        PubSize.text = CurrentPub.RacketSize;
        PubType.text = CurrentPub.RacketType;

        //building info regarding upgrades/costs/earnings

        //upgrade lvls
        pubSecurity.text = CurrentPub.pubSecurity.ToString();
        pubDeflect.text = CurrentPub.pubDeflect.ToString();
        pubAmbiance.text = CurrentPub.pubAmbiance.ToString();
        pubWordOfMouth.text = CurrentPub.pubWordOfMouth.ToString();

        //upgrade costs
        pubSecUpgradeCost.text = ((int)CurrentPub.pubSecUpgradeCost).ToString() + "$";
        pubDefUpgradeCost.text = ((int)CurrentPub.pubDefUpgradeCost).ToString() + "$";
        pubAmbiCost.text = ((int)CurrentPub.pubAmbiUpgradeCost).ToString() + "$";
        pubWOMCost.text = ((int)CurrentPub.pubWOMCost).ToString() + "$";

        //earnings and costs and police activity
        pubUpkeep.text = CurrentPub.pubUpkeep.ToString() + "$";
        pubEarning.text = CurrentPub.pubEarning.ToString() + "$";
        pubConsumption.text = CurrentPub.pubConsumption.ToString();
        pubPoliceActivity.text = CurrentPub.pubPoliceActivity.ToString();

    }
    #endregion
}

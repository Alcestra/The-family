using System.Collections.Generic;
using UnityEngine;


public class Bar : MonoBehaviour
{

    //Holds all the numbers for each pub

    public BarMenu pubMenu;
   

    //strings holding the name/size and type of racket
    [Header("Name size type")]
    public string RacketName;
    public string RacketSize;
    public string RacketType;

    //Floats for storing upkeep/consumtion/POL activity and upgrade lvls + costs
    [Header("Building info")]
    public int pubUpkeep;
    public int pubEarning;
    public int pubConsumption;
    public int pubPoliceActivity;

    [Header("Upgrade Lvls")]
    public int pubSecurity;
    public int pubDeflect;
    public int pubAmbiance;
    public int pubWordOfMouth;

    [Header("Upgrade costs")]
    public float pubSecUpgradeCost;
    public float pubDefUpgradeCost;
    public float pubAmbiUpgradeCost;
    public float pubWOMCost;

    public List<SpriteRenderer> SpriteRenderers;
    public Sprite BarSprite;

    private void Start()
    {
        foreach(SpriteRenderer renderer in SpriteRenderers)
        {
            renderer.sprite = BarSprite;
        }

        Resources.Instance.IncreaseTotalUpkeep(pubUpkeep);
        Resources.Instance.IncreaseTotalEarning(pubEarning);
        Resources.Instance.IncreaseTotalConsumption(pubConsumption);
        Resources.Instance.IncreaseTotalPoliceActivity(pubPoliceActivity);
    }

    public void OpenPubUI()
    {
        pubMenu.Open(this);
    }

    //lvl update for each upgrade
    #region upgrade lvl
    public void UpgradeSEC()
    {
        pubSecurity += 1;
        pubUpkeep += 3;
        Resources.Instance.IncreaseTotalUpkeep(3);
        Resources.Instance.Spend((int)pubSecUpgradeCost);
        UpgradeCostsSec();
    }

    public void UpgradeDef()
    {
        pubDeflect += 1;
        pubUpkeep += 4;
        pubPoliceActivity -= 2;
        Resources.Instance.IncreaseTotalUpkeep(4);
        Resources.Instance.Spend((int)pubDefUpgradeCost);
        Resources.Instance.DecreaseTotalPoliceActivity(2);
        UpgradeCostsDEF();
    }

    public void UpgradeAmbi()
    {
        pubAmbiance += 1;
        pubUpkeep += 3;
        pubConsumption += 2;
        int previousEarnings = pubEarning;
        pubEarning = (int)(pubEarning * 1.2f);
        pubPoliceActivity += 4;
        Resources.Instance.IncreaseTotalUpkeep(3);
        Resources.Instance.Spend((int)pubAmbiUpgradeCost);
        Resources.Instance.IncreaseTotalConsumption(2);
        Resources.Instance.IncreaseTotalEarning(pubEarning - previousEarnings);
        Resources.Instance.IncreaseTotalPoliceActivity(4);
        UpGradeCostsAmbi();
    }

    public void UpgradeWOM()
    {
        pubWordOfMouth += 1;
        pubConsumption += 2;
        int previousEarnings = pubEarning;
        pubEarning = (int)(pubEarning * 1.25f);
        pubPoliceActivity += 2;
        Resources.Instance.Spend((int)pubWOMCost);
        Resources.Instance.IncreaseTotalConsumption(2);
        Resources.Instance.IncreaseTotalEarning(pubEarning - previousEarnings);
        Resources.Instance.IncreaseTotalPoliceActivity(2);
        UpgradeCostsWOM();
    }

    #endregion

    

    //Upgrade costs multiplyer 
    #region UPCosts
    void UpGradeCostsAmbi()
    {
        pubAmbiUpgradeCost += pubAmbiUpgradeCost * .5f;
    }

    void UpgradeCostsDEF()
    {
        pubDefUpgradeCost += pubDefUpgradeCost * 1.2f;
    }

    void UpgradeCostsSec()
    {
        pubSecUpgradeCost += pubSecUpgradeCost * 1.2f;
    }

    void UpgradeCostsWOM()
    {
        pubWOMCost += pubWOMCost * .75f;
    }
    #endregion
}

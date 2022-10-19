using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour
{
    public static Resources Instance;

    //displayed in the resourceMenu
    public int PlayerCash;
    public int currentLiqour;
    public int LiqourStorage;

    //calculating cash flow
    public int TotalUpkeep;
    public int TotalEarning;
    public int NetIncome;

    //calculating liqour base
    public int TotalProduction;
    public int TotalConsumption;
    public int NetProduction;
    public int TotalLiquor;

    //calculating the chances of police raids, this will start if your total score is above 50 then calculate each buildings chance
    public int TotalPoliceActivity;   

    public GameObject LoseScreen;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(WeeklyTimerCorutine());
        
    }
    public void Update()
    {
        NetIncome = TotalEarning - TotalUpkeep;
        NetProduction = TotalProduction - TotalConsumption;
        
    }

    // cash and liquor update for each week
    IEnumerator WeeklyTimerCorutine()
    {
        yield return new WaitForSeconds(5);
        if(PlayerCash < 0)
        {
            Time.timeScale = 0f;
            LoseScreen.SetActive(true);
        }
        else
        {
            PlayerCash += NetIncome;
        }
        
        if(currentLiqour + NetProduction > LiqourStorage)
        {
            currentLiqour = LiqourStorage;
        }
        else if(currentLiqour + NetProduction < 0)
        {
            Time.timeScale = 0f;
            LoseScreen.SetActive(true);
        }
        else
        {
            currentLiqour += NetProduction;
        }
        StartCoroutine(WeeklyTimerCorutine());
    }    

    public bool SpendCheck(float costValue)
    {
        if (costValue <= PlayerCash)
            return true;
        else
            return false;
    }

    //if enough cash to be able to buy upgrades, buildings,manpower
    public void Spend(int costValue)
    {
        PlayerCash -= costValue;        
    }

   
   

    public void IncreaseTotalUpkeep(int upkeepAdd)
    {
        TotalUpkeep += upkeepAdd;
    }

    public void DecreaseTotalUpKeep(int upkeepMinus)
    {
        TotalUpkeep -= upkeepMinus;
    }
    public void IncreaseTotalEarning(int EarningAdd)
    {
        TotalEarning += EarningAdd;
    }

    public void DecreaseTotalEarning(int EArningMinus)
    {
        TotalEarning -= EArningMinus;
    }

    public void IncreaseTotalProduction(int prodAdd)
    {
        TotalProduction += prodAdd;
    }

    public void DecreaseTotalProduction(int prodMinus)
    {
        TotalProduction -= prodMinus;
    }
    public void IncreaseTotalConsumption(int ConsumeAdd)
    {
        TotalConsumption += ConsumeAdd;
    }

    public void DecreaseTotalConsumption(int ConsumeLess)
    {
        TotalConsumption -= ConsumeLess;
    }

    public void IncreaseTotalPoliceActivity(int MorePolice)
    {
        TotalPoliceActivity += MorePolice;
    }

    public void DecreaseTotalPoliceActivity(int LessPolice)
    {
        TotalPoliceActivity -= LessPolice;
    }

}

//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearTransactions : MonoBehaviour
{
    [SerializeField] TraderManager traderManager;


    [SerializeField] int goldAllHonestly = 4;
    [SerializeField] int goldAllDishonestly = 2;
    [SerializeField] int goldCheat = 5;
    [SerializeField] int goldHonestly = 1;

    [SerializeField] int replacementCount = 20;
    [SerializeField] int chanceOfError = 5;

    public void NextYear()
    {
        foreach (Trader trader in traderManager.Traders)
        {
            trader.Gold = 0;
        }

        Transactions();

        traderManager.Traders.Sort();

        if (replacementCount * 2 < traderManager.Traders.Count)
            Replacement(replacementCount);

        traderManager.UpdateTable();
    }

    private void Replacement(int replacementCount)
    {
        Vector3 position;
        int tradersCount = traderManager.Traders.Count;

        for (int i = 0; i < replacementCount; i++) 
        {
            position = traderManager.Traders[i].transform.position;

            Destroy(traderManager.Traders[i].gameObject);

            Instantiate(traderManager.Traders[tradersCount - 1 - i], position, Quaternion.identity, transform);
        }
    }

    private void Transactions()
    {
        int tradersCount = traderManager.Traders.Count;
        int transactionCount;

        for (int i = 0; i < tradersCount - 1; i++)
            for (int j = i + 1; j < tradersCount; j++)
            {
                traderManager.Traders[i].ITraderStandart.NewOpponent();
                traderManager.Traders[j].ITraderStandart.NewOpponent();

                transactionCount = Random.Range(5, 11);
                for (int k = 0; k < transactionCount; k++)
                {
                    Transaction(traderManager.Traders[i], traderManager.Traders[j]);
                }
            }

        //foreach (Trader trader in traderManager.Traders)
        //    trader.ITraderStandart.NewOpponent();
    }

    private void Transaction(Trader trader1, Trader trader2)
    {
        bool choiseTrader1 = trader1.ITraderStandart.Strategy();
        bool choiseTrader2 = trader2.ITraderStandart.Strategy();

        if (Random.Range(0, 100) < chanceOfError)
            choiseTrader1 = !choiseTrader1;
        if (Random.Range(0, 100) < chanceOfError)
            choiseTrader2 = !choiseTrader2;

        if (choiseTrader1 == true && choiseTrader2 == true)
        {
            trader1.Gold += goldAllHonestly;
            trader2.Gold += goldAllHonestly;
        }
        else if (choiseTrader1 == true && choiseTrader2 == false)
        {
            trader1.Gold += goldHonestly;
            trader2.Gold += goldCheat;
        }
        else if (choiseTrader1 == false && choiseTrader2 == true)
        {
            trader1.Gold += goldCheat;
            trader2.Gold += goldHonestly;
        }
        else if (choiseTrader1 ==false && choiseTrader2 == false)
        {
            trader1.Gold += goldAllDishonestly;
            trader2.Gold += goldAllDishonestly;
        }

        trader1.ITraderStandart.ChangingTheStrategy(choiseTrader2);
        trader2.ITraderStandart.ChangingTheStrategy(choiseTrader1);
    }
}

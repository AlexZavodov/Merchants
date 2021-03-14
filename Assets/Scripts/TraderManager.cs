using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TraderManager : MonoBehaviour
{
    [SerializeField] private TableController tableController;

    [SerializeField] private List<Trader> traders = new List<Trader>();


    public List<Trader> Traders
    {
        get
        {
            return traders;
        }
        set
        {
            traders = value;
        }
    }
    public void Awake()
    {
        Trader.TraderSpawned += AddTrader;
        Trader.TraderDespawned += RemoveTrader;
    }

    public void Start()
    {
        UpdateTable();
    }

    public void UpdateTable()
    {
        if (tableController.Lines.Count < traders.Count)
            tableController.RecreateTable(traders.Count);

        tableController.UpdateTable(traders);
    }

    private void AddTrader (Trader trader)
    {
        Traders.Add(trader);
    }

    private void RemoveTrader (Trader trader)
    {
        Traders.Remove(trader);
    }

}

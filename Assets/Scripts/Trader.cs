using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Sprites;


public class Trader : MonoBehaviour, IComparable<Trader>
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] TraderStandart traderStandart;
    ITraderStandart itraderStandart;

    [SerializeField] int gold = 0;

    #region

    public TraderStandart TraderStandart
    {
        get
        {
            return traderStandart;
        }
    }

    public ITraderStandart ITraderStandart
    {
        get
        {
            return itraderStandart;
        }
    }
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
        }
    }
    #endregion

    public static event Action<Trader> TraderSpawned;
    public static event Action<Trader> TraderDespawned;

    public int CompareTo(Trader other)
    {
        return this.Gold.CompareTo(other.Gold);
    }

    public void Start()
    {
        TraderSpawned?.Invoke(this);

        itraderStandart = traderStandart.GetComponent<ITraderStandart>();
    }

    public void OnDestroy()
    {
        TraderDespawned?.Invoke(this);
    }

}

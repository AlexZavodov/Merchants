using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vindictive : TraderStandart, ITraderStandart
{
    bool isCheated = false;

    public bool Strategy()
    {
        return !isCheated;
    }
    public void ChangingTheStrategy(bool OpponentMove)
    {
        if (!OpponentMove) isCheated = true;
    }
    public void NewOpponent() 
    {
        isCheated = false;
    }
}

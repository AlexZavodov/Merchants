using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altruist : TraderStandart, ITraderStandart
{

    public bool Strategy()
    {
        return true;
    }
    public void ChangingTheStrategy(bool OpponentMove){}

    public void NewOpponent() { }
}

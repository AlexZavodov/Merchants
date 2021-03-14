using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheater : TraderStandart, ITraderStandart
{

    public bool Strategy()
    {
        return false;
    }

    public void ChangingTheStrategy(bool OpponentMove) { }

    public void NewOpponent() { }
}

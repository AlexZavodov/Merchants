using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unpredictable : TraderStandart, ITraderStandart
{

    public bool Strategy()
    {
        return Random.value > 0.5f;
    }
    public void ChangingTheStrategy(bool OpponentMove) { }
    public void NewOpponent() { }
}

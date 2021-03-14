using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodger : TraderStandart, ITraderStandart
{
    bool stepOne = true;
    bool LastOpponentMove;

    public bool Strategy()
    {
        if (stepOne) return true;

        return LastOpponentMove;
    }
    public void ChangingTheStrategy(bool OpponentMove)
    {
        stepOne = false;
        LastOpponentMove = OpponentMove;
    }

    public void NewOpponent() 
    {
        stepOne = true;
    }
}

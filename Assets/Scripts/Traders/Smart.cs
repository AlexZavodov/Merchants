using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smart : TraderStandart, ITraderStandart
{
    int step = 0;

    bool isCheated = false;
    bool LastOpponentMove;

    public bool Strategy()
    {
        if (step == 0 || step == 2 || step == 3)
            return true;
        if (step == 1) 
            return false;

        if (isCheated)
            return false;
        else
            return LastOpponentMove;
    }

    public void ChangingTheStrategy(bool OpponentMove)
    {
        if (step < 4)
        {   
            if (!OpponentMove)
                isCheated = true;

            step++;
            return;
        }

        LastOpponentMove = OpponentMove;
    }

    public void NewOpponent() 
    {
        step = 0;
        isCheated = false;
    }
}

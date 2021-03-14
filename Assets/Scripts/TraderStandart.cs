using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITraderStandart
{
    public bool Strategy();
    public void ChangingTheStrategy(bool OpponentMove);
    public void NewOpponent();
}

public abstract class TraderStandart : MonoBehaviour
{
}


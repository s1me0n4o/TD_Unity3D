using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    public static int money;
    public int startMoney = 500;

    void Start()
    {
        money = startMoney;
    }
}

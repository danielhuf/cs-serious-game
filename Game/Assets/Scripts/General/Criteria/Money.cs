using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float curMoney;
    public float maxMoney;
    private float curMoneySlow;

    public MoneyBar moneyBar;
    public MoneyBar resultsMoneyBar;

    float t = 0;
    void Update()
    {
        if (curMoneySlow != curMoney)
        {
            curMoneySlow = Mathf.Lerp(curMoneySlow, curMoney, t);
            t += 0.5f * Time.deltaTime / 3;
        }
        else
        {
            t = 0;
        }
        UpdateBar();
    }

    public void UpdateMoney(int points)
    {
        curMoney += points;
        if (curMoney > maxMoney)
        {
            curMoney = maxMoney;
        }else if (curMoney <= 0)
        {
            curMoney = 0;
        }
    }

    public void UpdateBar()
    {
        moneyBar.SetMoney(curMoneySlow);
        resultsMoneyBar.SetMoney(curMoneySlow);
    }
}

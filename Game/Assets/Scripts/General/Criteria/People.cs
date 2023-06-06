using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    public float curPeople;
    public float maxPeople;
    private float curPeopleSlow;

    public PeopleBar peopleBar;
    public PeopleBar resultsPeopleBar;

    float t = 0;
    private void Update()
    {
        if (curPeopleSlow != curPeople)
        {
            curPeopleSlow = Mathf.Lerp(curPeopleSlow, curPeople, t);
            t += 0.5f * Time.deltaTime / 3;
        }
        else
        {
            t = 0;
        }
        UpdateBar();
    }

    public void UpdatePeople(int points)
    {
        curPeople += points;
        if (curPeople > maxPeople)
        {
            curPeople = maxPeople;
        } else if (curPeople <= 0)
        {
            curPeople = 0;
        }
    }

    public void UpdateBar()
    {
        peopleBar.SetPeople(curPeopleSlow);
        resultsPeopleBar.SetPeople(curPeopleSlow);
    }
}

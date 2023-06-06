using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Political : MonoBehaviour
{
    public float curPolitical;
    public float maxPolitical;
    private float curPoliticalSlow;

    public PoliticalBar politicalBar;
    public PoliticalBar resultsPoliticalBar;

    //void Start()
    //{
    //    curPolitical = maxPolitical;
    //}
    float t=0;
    void Update()
    {
        if (curPoliticalSlow != curPolitical)
        {
            curPoliticalSlow = Mathf.Lerp(curPoliticalSlow, curPolitical, t);
            t += 0.5f * Time.deltaTime / 3;
        }
        else
        {
            t = 0;
        }
        UpdateBar();
    }

    public void UpdatePolitical(int points)
    {
        curPolitical += points;
        if (curPolitical > maxPolitical)
        {
            curPolitical = maxPolitical;
        } else if (curPolitical <= 0)
        {
            curPolitical = 0;
        }
    }

    public void UpdateBar()
    {
        politicalBar.SetPolitical(curPoliticalSlow);
        resultsPoliticalBar.SetPolitical(curPoliticalSlow);
    }
}

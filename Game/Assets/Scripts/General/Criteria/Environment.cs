using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public float curEnvironment;
    public float maxEnvironment;
    private float curEnvironmentSlow;

    public EnvironmentBar environmentBar;
    public EnvironmentBar resultsEnvironmentBar;

    float t = 0;
    void Update()
    {
        if(curEnvironmentSlow != curEnvironment)
        {
            curEnvironmentSlow = Mathf.Lerp(curEnvironmentSlow, curEnvironment, t);
            t += 0.5f * Time.deltaTime/3; 
        } else
        {
            t = 0;
        }
        UpdateBar();
    }

    public void UpdateEnvironment(int points)
    {
        curEnvironment += points;
        if (curEnvironment > maxEnvironment)
        {
            curEnvironment = maxEnvironment;
        } else if (curEnvironment <= 0)
        {
            curEnvironment = 0;
        }
        
    }

    public void UpdateBar()
    {
        environmentBar.SetEnvironment(curEnvironmentSlow);
        resultsEnvironmentBar.SetEnvironment(curEnvironmentSlow);
    }

}

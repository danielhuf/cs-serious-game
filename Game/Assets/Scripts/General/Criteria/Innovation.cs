using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innovation : MonoBehaviour
{
    public float curInnovation;
    public float maxInnovation;
    private float curInnovationSlow;

    public InnovationBar innovationBar;
    public InnovationBar resultsInnovationBar;

    float t = 0;
    void Update()
    {
        if (curInnovationSlow != curInnovation)
        {
            curInnovationSlow = Mathf.Lerp(curInnovationSlow, curInnovation, t);
            t += 0.5f * Time.deltaTime / 3;
        }
        else
        {
            t = 0;
        }
        UpdateBar();
    }

    public void UpdateInnovation(int points)
    {
        curInnovation += points;
        if(curInnovation > maxInnovation)
        {
            curInnovation = maxInnovation;
        } else if (curInnovation <= 0)
        {
            curInnovation = 0;
        }
    }

    public void UpdateBar()
    {
        innovationBar.SetInnovation(curInnovationSlow);
        resultsInnovationBar.SetInnovation(curInnovationSlow);
    }
}

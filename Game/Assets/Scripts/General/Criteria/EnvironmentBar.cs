using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvironmentBar : MonoBehaviour
{
    public Slider environmentBar;
    public Environment playerEnvironment;

    private void Start()
    {
        playerEnvironment = GameObject.FindGameObjectWithTag("Player").GetComponent<Environment>();
        environmentBar = GetComponent<Slider>();
        environmentBar.maxValue = playerEnvironment.maxEnvironment;
        environmentBar.value = playerEnvironment.curEnvironment;
    }

    public void SetEnvironment(float value)
    {
        environmentBar.value = value;
        //float speed = 10f; //Defines how fast it switches between the 2 values
        //environmentBar.value = Mathf.Lerp(environmentBar.value, value, Time.deltaTime * speed);
    }
}
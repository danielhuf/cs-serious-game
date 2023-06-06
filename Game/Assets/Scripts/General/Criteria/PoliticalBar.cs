using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoliticalBar : MonoBehaviour
{
    public Slider politicalBar;
    public Political playerPolitical;

    private void Start()
    {
        playerPolitical = GameObject.FindGameObjectWithTag("Player").GetComponent<Political>();
        politicalBar = GetComponent<Slider>();
        politicalBar.maxValue = playerPolitical.maxPolitical;
        politicalBar.value = playerPolitical.curPolitical;

        //UIManager.instance.panelInGame.UpdatePlayerValues();

    }

    public void SetPolitical(float value)
    {
        politicalBar.value = value;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelEndPeriod : MonoBehaviour
{
    public TextMeshProUGUI innovationComment;
    public TextMeshProUGUI moneyComment;
    public TextMeshProUGUI peopleComment;
    public TextMeshProUGUI politicalComment;
    public TextMeshProUGUI environmentComment;

    private Dictionary<string, TextMeshProUGUI> commentsDict;

    // Start is called before the first frame update
    public void StartDict()
    {
        commentsDict = new Dictionary<string, TextMeshProUGUI>
        {
            { "Innovation", innovationComment },
            { "Finance", moneyComment },
            { "Popularity", peopleComment },
            { "Political alliance", politicalComment },
            { "Environment", environmentComment }
        };
    }

    public void UpdateComment(string type, int prevValue, int newValue)
    {
        int maxValue = 5;
        int dangerValue = 2;

        string comparisonComment = "";
        if (prevValue < newValue)
        {
            comparisonComment += type + " has improved this week.";
        } else if (prevValue > newValue)
        {
            comparisonComment += type + " has worsened this week.";
        } else
        {
            comparisonComment += "Not many changes with " + type + " this week.";
        }

        string thresholdComment = ""; // Will say this when over/under a certain threshold 
        if (newValue == maxValue)
        {
            thresholdComment += " Couldn't be better!";
        } else if (newValue <= dangerValue)
        {
            thresholdComment += " Virtua should be careful in this area.";
        }

        commentsDict[type].text = comparisonComment + thresholdComment;
    }


}

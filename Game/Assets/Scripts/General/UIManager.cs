using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject panelWelcomePage;
    public GameObject panelIntroduction;
    public PanelInGame panelInGame;
    public GameObject panelGameOver;
    public PanelEndPeriod panelEndPeriod;
    public GameObject panelCertificate;

    // Actor UI
    public GameObject ActorName;
    public GameObject ActorImage;

    public GameObject RightKeyText;
    public GameObject LeftKeyText;

    // Date Text
    public GameObject Date;
    public GameObject ResultsDate;

    // Dialogue Controller
    public DialogueController dialogueController;

    // GameOver texts
    public TextMeshProUGUI gameOverCause;
    public TextMeshProUGUI weeksLasted;

    private static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UIManager>();
            }
            return _instance;
        }
    }

    public void GoToStateWelcome()
    {
        panelWelcomePage.SetActive(true);
        panelIntroduction.SetActive(false);
        panelInGame.gameObject.SetActive(false);
        panelEndPeriod.gameObject.SetActive(false);
        panelGameOver.SetActive(false);
        panelCertificate.SetActive(false);
    }

    public void GoToStateIntroduction()
    {
        panelWelcomePage.SetActive(false);
        panelIntroduction.SetActive(true);
        panelInGame.gameObject.SetActive(false);
        panelEndPeriod.gameObject.SetActive(false);
        panelGameOver.SetActive(false);
        panelCertificate.SetActive(false);
    }

    public void GoToStateInGame()
    {
        panelWelcomePage.SetActive(false);
        panelIntroduction.SetActive(false);
        panelInGame.gameObject.SetActive(true);
        panelEndPeriod.gameObject.SetActive(false);
        panelGameOver.SetActive(false);
        panelCertificate.SetActive(false);
    }

    public void GoToStateEndPeriod()
    {
        // Update All comments
        panelEndPeriod.UpdateComment("Innovation", (int)Player.instance.innovation.innovationBar.innovationBar.value, (int)Player.instance.innovation.curInnovation);
        panelEndPeriod.UpdateComment("Finance", (int)Player.instance.money.moneyBar.moneyBar.value, (int)Player.instance.money.curMoney);
        panelEndPeriod.UpdateComment("Popularity", (int)Player.instance.people.peopleBar.peopleBar.value, (int)Player.instance.people.curPeople);
        panelEndPeriod.UpdateComment("Political alliance", (int)Player.instance.political.politicalBar.politicalBar.value, (int)Player.instance.political.curPolitical);
        panelEndPeriod.UpdateComment("Environment", (int)Player.instance.environment.environmentBar.environmentBar.value, (int)Player.instance.environment.curEnvironment);

        panelWelcomePage.SetActive(false);
        panelIntroduction.SetActive(false);
        panelInGame.gameObject.SetActive(false);
        panelEndPeriod.gameObject.SetActive(true);
        panelGameOver.SetActive(false);
        panelCertificate.SetActive(false);
    }

    public void GoToStateGameOver()
    {
        panelWelcomePage.SetActive(false);
        panelIntroduction.SetActive(false);
        panelInGame.gameObject.SetActive(false);
        panelEndPeriod.gameObject.SetActive(false);
        panelGameOver.SetActive(true);
        panelCertificate.SetActive(false);
    }

    public void GoToStateCertificate()
    {
        panelWelcomePage.SetActive(false);
        panelIntroduction.SetActive(false);
        panelInGame.gameObject.SetActive(false);
        panelEndPeriod.gameObject.SetActive(false);
        panelGameOver.SetActive(false);
        panelCertificate.SetActive(true);
    }

    public void SetCardText(string actorName, string actorDialog, string rightKeyText, string leftKeyText)
    {
        TextMeshProUGUI ActorName1 = ActorName.GetComponent<TextMeshProUGUI>();
        ActorName1.text = actorName;

        dialogueController.NextDialog(actorDialog);

        Image ActorImage1 = ActorImage.GetComponent<Image>();
        string dataPath = "characters/" + actorName;
        Sprite actorSprite = Resources.Load<Sprite>(dataPath);

        ActorImage1.sprite = actorSprite;

        TextMeshProUGUI RightKeyText1 = RightKeyText.GetComponent<TextMeshProUGUI>();
        RightKeyText1.text = rightKeyText;

        TextMeshProUGUI LeftKeyText1 = LeftKeyText.GetComponent<TextMeshProUGUI>();
        LeftKeyText1.text = leftKeyText;
    }

    public void SetDate(int week, int day)
    {
        TextMeshProUGUI Date1 = Date.GetComponent<TextMeshProUGUI>();
        Date1.text = "Week " + week + ", Day " + day;
    }

    public void SetResultsDate(int week)
    {
        TextMeshProUGUI ResultsDate1 = ResultsDate.GetComponent<TextMeshProUGUI>();
        ResultsDate1.text = "Week " + week;
    }

    public void SetGameOverCause(string cause)
    {
        string text;
        switch (cause)
        {
            case "Innovation":
                text = "Virtua couldn't keep up with the innovative competence";
                break;
            case "Money":
                text = "Virtua went bankrupt!";
                break;
            case "People":
                text = "People do not have any trust in Virtua anymore";
                break;
            case "Environment":
                text = "Virtua was closed due to 'irreversible damage to the environment'";
                break;
            case "Political":
                text = "A politician pulled some strings to close Virtua";
                break;
            default:
                text = "Bad weather today huh?";
                break;
        }
        gameOverCause.text = text;
    }

    public void SetWeeksLasted(int weeks)
    {
        weeksLasted.text = "You lasted " + weeks.ToString() + " weeks";
    }
}

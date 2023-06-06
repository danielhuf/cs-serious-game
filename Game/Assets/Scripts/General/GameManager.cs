using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int currentDay;
    public int currentWeek;
    public List<Decision> decisionList;

    private string gameOverCause;


    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentDay = 1;
        currentWeek = 1;
        UIManager.instance.SetDate(currentWeek, currentDay);
        decisionList = new List<Decision>();
    }

    public void TakeDecision(string cardId, int decision)
    {
        Decision newDecision = gameObject.AddComponent<Decision>();
        newDecision.cardid = cardId;
        newDecision.decision = decision;
        decisionList.Add(newDecision);
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        UIManager.instance.GoToStateEndPeriod();
        UIManager.instance.SetResultsDate(currentWeek);
    }

    public void NextDay()
    {
        if (currentDay == 5)
        {

            StartCoroutine(waiter());

        } else
        {
            currentDay++;
            UIManager.instance.SetDate(currentWeek, currentDay);
            DecisionCardManager.instance.GetRandomDecisionCard();
        }
        
    }

    public void NextWeek()
    {
        if(IsGameOver())
        {
            UIManager.instance.GoToStateGameOver();
            UIManager.instance.SetGameOverCause(gameOverCause);
            UIManager.instance.SetWeeksLasted(currentWeek);

        } else
        {
            currentDay = 1;
            currentWeek++;
            UIManager.instance.GoToStateInGame();
            DecisionCardManager.instance.GetRandomDecisionCard();
            UIManager.instance.SetDate(currentWeek, currentDay);
        }
    }

    public void RestartGame()
    {
        decisionList = new List<Decision>();
        currentDay = 1;
        currentWeek = 1;
        UIManager.instance.SetDate(currentWeek, currentDay);
        Player.instance.money.curMoney = 3;
        Player.instance.innovation.curInnovation = 3;
        Player.instance.people.curPeople = 3;
        Player.instance.environment.curEnvironment = 3;
        Player.instance.political.curPolitical = 3;
        DecisionCardManager.instance.Restart();
        UIManager.instance.GoToStateWelcome();
    }

    private bool IsGameOver()
    {
        bool gameOver = false;
        if (Player.instance.money.curMoney <= 0)
        {
            gameOverCause = "Money";
            gameOver = true;
        }
        else if (Player.instance.innovation.curInnovation <= 0)
        {
            gameOverCause = "Innovation";
            gameOver = true;

        }
        else if (Player.instance.people.curPeople <= 0)
        {
            gameOverCause = "People";
            gameOver = true;
        }
        else if (Player.instance.environment.curEnvironment <= 0)
        {
            gameOverCause = "Environment";
            gameOver = true;
        }
        else if (Player.instance.political.curPolitical <= 0)
        {
            gameOverCause = "Political";
            gameOver = true;
        }

        return gameOver;
    }

    public void UpdateValues(int decisionKey)
    {
        // UPDATE WITH THE KEY INSTEAD OF INDEX
        DecisionCard currentCard = DecisionCardManager.instance.currentCard;
        Answer chosenAnswer;
        for (int i = 0; i < currentCard.answers.Count; i++)
        {
            if (currentCard.answers[i].key == decisionKey)
            {
                chosenAnswer = currentCard.answers[i];
                Player.instance.money.UpdateMoney(chosenAnswer.values.money);
                Player.instance.innovation.UpdateInnovation(chosenAnswer.values.innovation);
                Player.instance.people.UpdatePeople(chosenAnswer.values.people);
                Player.instance.environment.UpdateEnvironment(chosenAnswer.values.environment);
                Player.instance.political.UpdatePolitical(chosenAnswer.values.political);

                TakeDecision(currentCard.id, decisionKey);
            }
        }
    }


}

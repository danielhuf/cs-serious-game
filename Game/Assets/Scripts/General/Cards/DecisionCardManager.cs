using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DecisionCardManager : MonoBehaviour
{
    public CardList cardList;
    public CardList potentialCardList;
    public CardList originalCardList;
    public DecisionCard currentCard;

    private static DecisionCardManager _instance;
    public static DecisionCardManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<DecisionCardManager>();
            }
            return _instance;
        }
    }


    void Start()
    {
        string filePath = Application.streamingAssetsPath + "/Cards.json";
        string jsonString = File.ReadAllText(filePath);
        cardList = JsonUtility.FromJson<CardList>(jsonString);
        potentialCardList = new CardList();
        potentialCardList.decisionCards = new List<DecisionCard>(cardList.decisionCards);
        originalCardList = new CardList();
        originalCardList.decisionCards = new List<DecisionCard>(cardList.decisionCards);
    }

    public void Restart()
    {
        cardList.decisionCards = new List<DecisionCard>(originalCardList.decisionCards);
        potentialCardList.decisionCards = new List<DecisionCard>(originalCardList.decisionCards);
    }

    public void GetRandomDecisionCard()
    {
        bool found = false;
        int index;
        while (!found && potentialCardList.decisionCards.Count > 0)
        {
            index = Random.Range(0, potentialCardList.decisionCards.Count);
            currentCard = potentialCardList.decisionCards[index];
            potentialCardList.decisionCards.RemoveAt(index);

            if (CanTakeDecision())
            {
                found = true;
                for (int i=0; i<cardList.decisionCards.Count; i++)
                {
                    if(cardList.decisionCards[i].id == currentCard.id)
                    {
                        cardList.decisionCards.RemoveAt(i);
                    }
                }

                potentialCardList.decisionCards = new List<DecisionCard>(cardList.decisionCards);
            }
        }

        if (found == false)
        {
            UIManager.instance.GoToStateCertificate();
        } else
        {
            string rightKeyText = currentCard.answers[0].content;
            string leftKeyText = currentCard.answers[1].content;

            // Set UI Card text
            UIManager.instance.SetCardText(currentCard.actor, currentCard.content, rightKeyText, leftKeyText);
        }
    }

    public bool CanTakeDecision()
    {
        // no dependency check
        if(currentCard.dependency.Count == 0)
        {
            return true;
        }

        // check player's decisions
        List<Decision> decisionList = GameManager.instance.decisionList;

        for (int i = 0; i < decisionList.Count; i++)
        {
            Dependency depencency = currentCard.dependency[0];
            if (depencency.cardid == decisionList[i].cardid && depencency.decision == decisionList[i].decision) {
                return true;
            }
        }

        return false;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public enum STATE { WELCOME_PAGE, IN_GAME, GAME_OVER };

    public STATE state;

    public UIManager uiManager;
    public Player player;

    public AudioSource buttonClick;

    private static Main _instance;
    public static Main instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Main>();
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Main is starting"); // can be LogWarning to show in a different color
        uiManager.GoToStateWelcome();
    }


    public void LaunchGame ()
    {
        state = STATE.IN_GAME;
        uiManager.GoToStateInGame();
    }

    public void OnButtonPress()
    {
        buttonClick.Play();
    }

    public void doExitGame()
    {
        Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{

    public TextMeshProUGUI DialogueText;
    public string Sentence;
    public float DialogueSpeed;
    IEnumerator writeCoroutine;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            StopCoroutine(writeCoroutine);
            DialogueText.text = Sentence;
        }
    }

    public void NextDialog(string sentence)
    {
        writeCoroutine = WriteSentence();
        Sentence = sentence;
        DialogueText.text = "";
        StartCoroutine(writeCoroutine);
    }

    IEnumerator WriteSentence()
    {
        foreach(char Character in Sentence.ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
    }
}

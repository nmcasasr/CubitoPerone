using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI textElement,titleElement;
    public TextMeshProUGUI[] texts;
    private Queue<string> sentences;

    public Animator animator;
    public GameObject dialogCanvas;
    public float time = 1.5f;
    public SoundManager soundManager;

    void Start()
    {
        sentences = new Queue<string>();
        soundManager = FindObjectOfType<SoundManager>();
        dialogCanvas = GameObject.FindGameObjectWithTag("Dialog");
        animator = dialogCanvas.GetComponent<Animator>();
        texts = dialogCanvas.GetComponentsInChildren<TextMeshProUGUI>();
        textElement = texts[1];
        titleElement = texts[0];
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        titleElement.text = dialogue.title;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        //textElement.text = sentence; 
        //Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        textElement.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            textElement.text += letter;
            yield return null;
        }
        yield return new WaitForSeconds(3);
        DisplayNextSentence();
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}

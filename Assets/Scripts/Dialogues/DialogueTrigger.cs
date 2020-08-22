using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public SoundManager soundManager;
    public string dialogType;

    public void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void TriggerDialog()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            soundManager.PlayDialogSound(dialogType);
            TriggerDialog();
        }
    }
}

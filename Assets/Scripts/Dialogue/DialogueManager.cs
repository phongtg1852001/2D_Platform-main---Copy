using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text npcNameText;
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;

    private Queue<string> sentences;
    private bool isDialogueActive;
    private bool canInteract;
    private Dialogue currentDialogue;

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
        canInteract = false;
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.G))
        {
            if (isDialogueActive)
            {
                DisplayNextSentence();
            }
            else
            {
                StartDialogue(currentDialogue);
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogue == null)
        {
            Debug.LogError("Dialogue is null!");
            return;
        }

        isDialogueActive = true; // Set isDialogueActive to true
        dialoguePanel.SetActive(true);
        npcNameText.text = dialogue.npcName;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
        FindObjectOfType<QuestManager>().CompleteCurrentQuest();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
            currentDialogue = GetComponent<Dialogue>();
            if (currentDialogue == null)
            {
                Debug.LogError("No Dialogue component found on NPC!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
            dialoguePanel.SetActive(false);
            currentDialogue = null;
        }
    }
}

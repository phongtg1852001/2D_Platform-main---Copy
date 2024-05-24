using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public List<Quest> Quests;
    public TMP_Text questNameText;
    public TMP_Text questProgressText;
    private int currentQuestIndex = 0;

    private void Start()
    {
        UpdateQuestUI();
    }

    public void CompleteCurrentQuest()
    {
        if (currentQuestIndex < Quests.Count)
        {
            Quests[currentQuestIndex].isCompleted = true;
            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                player.attackDamage += Quests[currentQuestIndex].rewardDamage;
                player.runSpeed += Quests[currentQuestIndex].rewardSpeed;
            }
            currentQuestIndex++;
            UpdateQuestUI();
        }
    }

    public void CheckQuestProgress()
    {
        if (currentQuestIndex < Quests.Count)
        {
            Quest currentQuest = Quests[currentQuestIndex];
            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                if (currentQuest.type == QuestType.DefeatEnemies && player.enemiesDefeated >= currentQuest.targetCount)
                {
                    CompleteCurrentQuest();
                }
                else if (currentQuest.type == QuestType.DefeatBoss && player.bossDefeated)
                {
                    CompleteCurrentQuest();
                }
            }
        }
    }

    private void UpdateQuestUI()
    {
        if (currentQuestIndex < Quests.Count)
        {
            Quest currentQuest = Quests[currentQuestIndex];
            questNameText.text = "Current Quest: " + currentQuest.questName;
            if (currentQuest.type == QuestType.TalkToNPC)
            {
                questProgressText.text = "Talk to the NPC";
            }
            else if (currentQuest.type == QuestType.DefeatEnemies)
            {
                PlayerController player = FindObjectOfType<PlayerController>();
                questProgressText.text = $"Defeat {player.enemiesDefeated}/{currentQuest.targetCount} enemies";
            }
            else if (currentQuest.type == QuestType.DefeatBoss)
            {
                questProgressText.text = "Defeat the boss";
            }
        }
        else
        {
            questNameText.text = "All quests completed!";
            questProgressText.text = "";
        }
    }
}

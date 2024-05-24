using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    TalkToNPC,
    DefeatEnemies,
    DefeatBoss
}

[System.Serializable]
public class Quest
{
    public string questName;
    public QuestType type;
    public bool isCompleted;
    public int targetCount; 
    public int rewardDamage;
    public int rewardSpeed;
}

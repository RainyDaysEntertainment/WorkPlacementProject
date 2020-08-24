using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Quest
{
    public bool isComplete = false, itemReturned = false;

    public string QuestTitle, QuestDescription;
    public Sprite QuestImage, QuestImageSilhouette, QuestBack;
}

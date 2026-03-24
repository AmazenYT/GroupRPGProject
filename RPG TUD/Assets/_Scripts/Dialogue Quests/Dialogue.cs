using System;
using UnityEngine;

[Serializable]
public class DialogueLine
{
    public string speaker;

    [TextArea(2, 5)]
    public string text;
    public AudioClip voiceLine;

    [Header("Quest Actions")]
    public Quest questToStart;
    public Quest questToComplete;
}

[CreateAssetMenu(menuName = "RPG/Dialogue")]
public class Dialogue : ScriptableObject
{
    public DialogueLine[] lines;
}

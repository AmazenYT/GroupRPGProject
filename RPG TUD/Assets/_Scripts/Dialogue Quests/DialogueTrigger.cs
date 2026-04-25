using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue inProgressDialogue;
    public Dialogue completedDialogue;
    public Quest questToCheck;
    public string dialoguePrompt = "Press E to Talk";

    public void TriggerDialogue()
    {
        Dialogue selectedDialogue = GetDialogueForCurrentState();
        Debug.Log($"DialogueTrigger: questToCheck={questToCheck?.questID ?? "null"}, state={QuestManager.Instance?.GetQuestState(questToCheck) ?? QuestState.NotStarted}, selectedDialogue={selectedDialogue?.name ?? "null"}");

        if (selectedDialogue != null)
            DialogueManager.Instance.StartDialogue(selectedDialogue);
    }

    public Dialogue GetDialogueForCurrentState()
    {
        if (questToCheck == null)
            return dialogue;

        if (QuestManager.Instance == null)
            return dialogue;

        QuestState state = QuestManager.Instance.GetQuestState(questToCheck);
        Dialogue selectedDialogue = dialogue;

        switch (state)
        {
            case QuestState.InProgress:
                selectedDialogue = inProgressDialogue != null ? inProgressDialogue : dialogue;
                break;
            case QuestState.Completed:
                selectedDialogue = completedDialogue != null ? completedDialogue : dialogue;
                break;
        }

        Debug.Log($"DialogueTrigger.GetDialogueForCurrentState: questToCheck={questToCheck.questID}, state={state}, selectedDialogue={selectedDialogue?.name ?? "null"}");
        return selectedDialogue;
    }
}

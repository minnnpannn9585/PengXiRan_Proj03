using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : UIPanel
{
    [SerializeField] private Text dialogueText;
    [SerializeField] private Button nextButton;
    [SerializeField] private string[] dialogues;

    private int currentDialogueIndex = 0;

    void Awake()
    {
        nextButton.onClick.AddListener(OnNextClick);
    }

    public override void Show()
    {
        base.Show();
        currentDialogueIndex = 0;

        if (dialogues != null && dialogues.Length > 0)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
        else
        {
            dialogueText.text = string.Empty;
        }
    }

    private void OnNextClick()
    {
        currentDialogueIndex++;
        if (dialogues != null && currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
        else
        {
            GameManager.Instance.SwitchState(GameState.MainUI);
        }
    }
}
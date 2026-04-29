using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : UIPanel
{
    [SerializeField] private Text dialogueText; // 对话文本显示
    [SerializeField] private Button nextButton;  // 下一句按钮

    // 简单的对话内容数组
    private string[] dialogues = { "村民：请帮我们找到解药材料！", "你：放心交给我！" };
    private int currentDialogueIndex = 0;

    void Awake()
    {
        nextButton.onClick.AddListener(OnNextClick);
    }

    // 显示面板时重置对话
    public override void Show()
    {
        base.Show();
        currentDialogueIndex = 0;
        dialogueText.text = dialogues[currentDialogueIndex];
    }

    // 点击下一句
    private void OnNextClick()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
        }
        else
        {
            // 对话结束，切换到主界面
            GameManager.Instance.SwitchState(GameState.MainUI);
        }
    }
}
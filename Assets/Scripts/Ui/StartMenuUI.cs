using UnityEngine;
using UnityEngine.UI;

public class StartMenuUI : UIPanel
{
    [SerializeField] private Button startButton; // 开始游戏按钮

    void Awake()
    {
        // 绑定按钮事件
        startButton.onClick.AddListener(OnStartClick);
    }

    // 点击开始按钮：切换到对话界面
    private void OnStartClick()
    {
        GameManager.Instance.SwitchState(GameState.Dialogue);
    }
}
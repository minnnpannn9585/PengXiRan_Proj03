using UnityEngine;
using UnityEngine.UI;

public class MainUI : UIPanel
{
    [Header("功能按钮")]
    [SerializeField] private Button questButton;    // 任务按钮
    [SerializeField] private Button mapButton;      // 地图按钮
    [SerializeField] private Button inventoryButton;// 背包按钮
    [SerializeField] private Button alchemyButton;  // 炼药按钮

    [Header("子面板")]
    [SerializeField] private UIPanel questPanel;    // 任务面板
    [SerializeField] private UIPanel inventoryPanel;// 背包面板

    void Awake()
    {
        // 绑定按钮事件
        mapButton.onClick.AddListener(() => GameManager.Instance.SwitchState(GameState.Map));
        alchemyButton.onClick.AddListener(() => GameManager.Instance.SwitchState(GameState.Alchemy));
        questButton.onClick.AddListener(() => TogglePanel(questPanel));
        inventoryButton.onClick.AddListener(() => TogglePanel(inventoryPanel));
    }

    // 切换子面板显示/隐藏
    private void TogglePanel(UIPanel panel)
    {
        if (panel.gameObject.activeSelf) panel.Hide();
        else panel.Show();
    }
}
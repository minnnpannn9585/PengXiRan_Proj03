using UnityEngine;
using UnityEngine.UI;

public class ThankYouUI : UIPanel
{
    [SerializeField] private Text thankYouText; // 感谢文本

    // 显示面板时播放感谢
    public override void Show()
    {
        base.Show();
        thankYouText.text = "村民：太感谢你了！解药救了全村人！";
    }

    // 重新开始游戏
    private void RestartGame()
    {
        // 清空背包（可选）
        GameManager.Instance.playerInventory.ClearInventory();
        // 回到开始菜单
        GameManager.Instance.SwitchState(GameState.StartMenu);
    }
}
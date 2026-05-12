using UnityEngine;
using UnityEngine.UI;

public class AlchemyUI : UIPanel
{
    [SerializeField] private Recipe targetRecipe; // 目标配方（在Inspector配置）
    [SerializeField] private Button craftButton;   // 炼药按钮
    [SerializeField] private Button backButton;    // 返回按钮
    [SerializeField] private Text hintText;        // 提示文本

    void Awake()
    {
        //backButton.onClick.AddListener(() => GameManager.Instance.SwitchState(GameState.MainUI));
        //craftButton.onClick.AddListener(TryCraft);
    }

    // 显示面板时更新提示
    public override void Show()
    {
        base.Show();
        UpdateHint();
    }

    // 尝试炼药
    private void TryCraft()
    {
        var inventory = GameManager.Instance.playerInventory;

        // 检查材料是否足够
        if (inventory.HasItem(targetRecipe.material1) && inventory.HasItem(targetRecipe.material2))
        {
            // 消耗材料
            inventory.RemoveItem(targetRecipe.material1);
            inventory.RemoveItem(targetRecipe.material2);

            // 炼药成功，切换到感谢界面
            GameManager.Instance.SwitchState(GameState.ThankYou);
        }
        else
        {
            hintText.text = "材料不足！需要：" + targetRecipe.material1.itemName + " + " + targetRecipe.material2.itemName;
        }
    }

    // 更新提示文本
    private void UpdateHint()
    {
        hintText.text = "需要材料：" + targetRecipe.material1.itemName + " + " + targetRecipe.material2.itemName;
    }
}
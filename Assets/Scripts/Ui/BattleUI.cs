using UnityEngine;
using UnityEngine.UI;

public class BattleUI : UIPanel
{
    [SerializeField] private Text resultText; // 战斗结果文本
    [SerializeField] private GameObject battleHint; // 战斗提示（如“跳起来踩敌人！”）

    // 显示战斗中
    public void ShowBattle()
    {
        Show();
        resultText.gameObject.SetActive(false);
        battleHint.SetActive(true);
    }

    // 显示战斗结果
    public void ShowResult(string result)
    {
        battleHint.SetActive(false);
        resultText.gameObject.SetActive(true);
        resultText.text = result;
    }
}
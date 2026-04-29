using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem Instance;

    [Header("战斗物体引用")]
    [SerializeField] private PlayerController player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private BattleUI battleUI;

    private Item currentReward; // 当前战斗的奖励

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // 设置战斗奖励（由地图界面调用）
    public void SetBattleReward(Item reward)
    {
        currentReward = reward;
    }

    // 开始战斗
    public void StartBattle()
    {
        gameObject.SetActive(true);
        player.ResetPosition();
        enemy.ResetPosition();
        battleUI.ShowBattle();
    }

    // 玩家胜利
    public void OnPlayerWin()
    {
        // 添加药材到背包
        if (currentReward != null)
        {
            GameManager.Instance.playerInventory.AddItem(currentReward);
        }

        battleUI.ShowResult("战斗胜利！获得：" + currentReward.itemName);
        Invoke("ReturnToMainUI", 2f); // 2秒后返回主界面
    }

    // 玩家失败
    public void OnPlayerLose()
    {
        battleUI.ShowResult("战斗失败，再试一次吧！");
        Invoke("ReturnToMap", 2f); // 2秒后返回地图
    }

    // 返回主界面
    private void ReturnToMainUI()
    {
        GameManager.Instance.SwitchState(GameState.MainUI);
    }

    // 返回地图
    private void ReturnToMap()
    {
        GameManager.Instance.SwitchState(GameState.Map);
    }

    // 隐藏战斗系统
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
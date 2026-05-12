using UnityEngine;
using UnityEngine.UI;

public class MapUI : UIPanel
{
    [System.Serializable]
    public class MapLocation
    {
        public Button locationButton; // 地点按钮
        public Item rewardItem;       // 战斗胜利后获得的药材
    }

    [SerializeField] private MapLocation[] mapLocations; // 所有地点配置
    [SerializeField] private Button backButton;           // 返回主界面按钮

    void Awake()
    {
        //backButton.onClick.AddListener(() => GameManager.Instance.SwitchState(GameState.MainUI));

        // 绑定每个地点按钮的事件
        foreach (var location in mapLocations)
        {
            location.locationButton.onClick.AddListener(() =>
            {
                // 设置战斗奖励，然后进入战斗
                BattleSystem.Instance.SetBattleReward(location.rewardItem);
                GameManager.Instance.SwitchState(GameState.Battle);
            });
        }
    }
}
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 单例

    [Header("UI面板引用")]
    public StartMenuUI startMenuUI;
    public DialogueUI dialogueUI;
    public MainUI mainUI;
    public MapUI mapUI;
    public BattleSystem battleSystem;
    public AlchemyUI alchemyUI;
    public ThankYouUI thankYouUI;

    [Header("数据引用")]
    public Inventory playerInventory;

    private GameState currentState;

    void Awake()
    {
        // 单例初始化
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // 游戏开始时显示开始菜单
        SwitchState(GameState.StartMenu);
    }

    // 状态切换核心方法
    public void SwitchState(GameState newState)
    {
        currentState = newState;
        HideAllPanels(); // 先隐藏所有面板

        // 根据新状态显示对应内容
        switch (newState)
        {
            case GameState.StartMenu:
                startMenuUI.Show();
                break;
            case GameState.Dialogue:
                dialogueUI.Show();
                break;
            case GameState.MainUI:
                mainUI.Show();
                break;
            case GameState.Map:
                mapUI.Show();
                break;
            case GameState.Battle:
                battleSystem.StartBattle();
                break;
            case GameState.Alchemy:
                alchemyUI.Show();
                break;
            case GameState.ThankYou:
                thankYouUI.Show();
                break;
        }
    }

    // 隐藏所有UI面板
    private void HideAllPanels()
    {
        startMenuUI.Hide();
        dialogueUI.Hide();
        mainUI.Hide();
        mapUI.Hide();
        alchemyUI.Hide();
        thankYouUI.Hide();
        battleSystem.Hide();
    }
}
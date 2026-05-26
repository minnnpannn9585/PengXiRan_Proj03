using UnityEngine;
using UnityEngine.UI;

public class MainUI : UIPanel
{
    [Header("功能按钮")]
    [SerializeField] private Button questButton;         // 任务按钮
    [SerializeField] private Button mapButton;           // 地图按钮
    [SerializeField] private Button prescriptionButton;  // 药方按钮
    [SerializeField] private Button makeButton;          // 制作按钮
    [SerializeField] private Button collectionButton;    // 收藏按钮

    [Header("子面板")]
    [SerializeField] private UIPanel questPanel;         // 任务面板
    [SerializeField] private UIPanel mapPanel;           // 地图面板
    [SerializeField] private UIPanel prescriptionPanel;  // 药方面板
    [SerializeField] private UIPanel makePanel;          // 制作面板
    [SerializeField] private UIPanel collectionPanel;    // 收藏面板

    [Header("子面板返回按钮")]
    [SerializeField] private Button questBackButton;         // 任务面板返回按钮
    [SerializeField] private Button mapBackButton;           // 地图面板返回按钮
    [SerializeField] private Button prescriptionBackButton;  // 药方面板返回按钮
    [SerializeField] private Button makeBackButton;          // 制作面板返回按钮
    [SerializeField] private Button collectionBackButton;    // 收藏面板返回按钮

    void Awake()
    {
        questButton.onClick.AddListener(() => OpenPanel(questPanel));
        mapButton.onClick.AddListener(() => OpenPanel(mapPanel));
        prescriptionButton.onClick.AddListener(() => OpenPanel(prescriptionPanel));
        makeButton.onClick.AddListener(() => OpenPanel(makePanel));
        collectionButton.onClick.AddListener(() => OpenPanel(collectionPanel));

        questBackButton.onClick.AddListener(CloseAllSubPanels);
        mapBackButton.onClick.AddListener(CloseAllSubPanels);
        prescriptionBackButton.onClick.AddListener(CloseAllSubPanels);
        makeBackButton.onClick.AddListener(CloseAllSubPanels);
        collectionBackButton.onClick.AddListener(CloseAllSubPanels);
    }

    public override void Show()
    {
        base.Show();
        CloseAllSubPanels();
        SetMainButtonsVisible(true);
    }

    private void OpenPanel(UIPanel panel)
    {
        CloseAllSubPanels();
        panel.Show();
        SetMainButtonsVisible(false);
    }

    private void CloseAllSubPanels()
    {
        questPanel.Hide();
        mapPanel.Hide();
        prescriptionPanel.Hide();
        makePanel.Hide();
        collectionPanel.Hide();

        SetMainButtonsVisible(true);
    }

    private void SetMainButtonsVisible(bool visible)
    {
        questButton.gameObject.SetActive(visible);
        mapButton.gameObject.SetActive(visible);
        prescriptionButton.gameObject.SetActive(visible);
        makeButton.gameObject.SetActive(visible);
        collectionButton.gameObject.SetActive(visible);
    }
}
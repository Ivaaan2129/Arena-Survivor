using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LevelUpUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject panel;
    [SerializeField] private Button optionButton1;
    [SerializeField] private Button optionButton2;
    [SerializeField] private Button optionButton3;
    [SerializeField] private TextMeshProUGUI optionText1;
    [SerializeField] private TextMeshProUGUI optionText2;
    [SerializeField] private TextMeshProUGUI optionText3;

    private UpgradeType[] currentOptions = new UpgradeType[3];

    private void Update()
    {
        if (!panel.activeSelf) return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            SelectOption(0);

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            SelectOption(1);

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            SelectOption(2);
    }

    public void Show(UpgradeType[] options)
    {
        currentOptions = options;

        optionText1.text = GetUpgradeText(options[0]);
        optionText2.text = GetUpgradeText(options[1]);
        optionText3.text = GetUpgradeText(options[2]);

        optionButton1.onClick.RemoveAllListeners();
        optionButton2.onClick.RemoveAllListeners();
        optionButton3.onClick.RemoveAllListeners();

        optionButton1.onClick.AddListener(() => SelectOption(0));
        optionButton2.onClick.AddListener(() => SelectOption(1));
        optionButton3.onClick.AddListener(() => SelectOption(2));

        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Hide()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void SelectOption(int index)
    {
        FindFirstObjectByType<LevelUpManager>().ApplyUpgrade(currentOptions[index]);
        Hide();
    }

    private string GetUpgradeText(UpgradeType upgrade)
    {
        switch (upgrade)
        {
            case UpgradeType.MoveSpeed:
                return "Move Speed\nIncrease movement speed";
            case UpgradeType.FireRate:
                return "Fire Rate\nShoot faster";
            case UpgradeType.MagicBoltDamage:
                return "Magic Bolt Damage\nIncrease projectile damage";
            case UpgradeType.ProjectileSpeed:
                return "Projectile Speed\nIncrease projectile speed";
            case UpgradeType.MaxHealth:
                return "Max Health\nIncrease max health";
            case UpgradeType.Heal:
                return "Heal\nRecover health";
            default:
                return upgrade.ToString();
        }
    }
}
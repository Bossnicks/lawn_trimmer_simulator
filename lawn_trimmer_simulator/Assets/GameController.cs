using Assets;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public enum LineType { Weak, Medium, Strong }
    public LineType currentLineType;
    public static int sumOstraya = 0;
    public static int sumSrednya = 0;
    public static int sumSlabaya = 0;


    public float lineDurability;
    public float maxDurability;
    public int usedSpools = 1;
    private int flowerPenalty = 10;
    public int score = 0;

    private TextMeshProUGUI lineStatusText;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI spoolsText;
    private TextMeshProUGUI lineTypeText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        lineStatusText = GameObject.Find("LineDurability").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Scope").GetComponent<TextMeshProUGUI>();
        spoolsText = GameObject.Find("UsedSpools").GetComponent<TextMeshProUGUI>();
        lineTypeText = GameObject.Find("CurrentLineType").GetComponent<TextMeshProUGUI>();
        currentLineType = LineType.Medium;
        SetLineType(currentLineType);
        UpdateUI();
    }

    public void SetLineType(LineType newLineType)
    {
        currentLineType = newLineType;

        // Установка максимальной прочности в зависимости от типа лески
        switch (currentLineType)
        {
            case LineType.Weak:
                maxDurability = 500f;
                break;
            case LineType.Medium:
                maxDurability = 200f;
                break;
            case LineType.Strong:
                maxDurability = 100f;
                break;
        }

        lineDurability = maxDurability; // Сброс текущей прочности до максимальной
        UpdateUI();
    }

    public void DecreaseDurability(float amount)
    {
        lineDurability -= amount;
        if (lineDurability <= 0)
        {
            lineDurability = 0;
            TaskController.currentState = TaskController.TaskControllerEnum.MowingHasBeenSuspended;

        }
        UpdateUI();
    }

    //public void DecreaseDurability(string plant)
    //{
    //    switch (plant)
    //    {
    //        case "Rose":
    //            DecreaseDurability(10);
    //            break;
    //    }
    //    if (plant == "Rose")
    //    {
    //    }

    //}

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void ApplyFlowerPenalty()
    {
        score -= flowerPenalty;

        if (score < 0)
        {
            score = 0;
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        lineStatusText.text = $"Line Durability: {lineDurability}/{maxDurability}";
        scoreText.text = $"Score: {score}";
        spoolsText.text = $"Used Spools: {usedSpools}";
        lineTypeText.text = $"Line Type: {currentLineType}";
    }
    private void Update()
    {
        
    }
}

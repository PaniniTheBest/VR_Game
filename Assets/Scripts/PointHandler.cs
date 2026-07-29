using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointHandler : MonoBehaviour
{
    public static PointHandler instance { get; private set; }

    public TextMeshProUGUI currentScore_Txt;
    public TextMeshProUGUI highScore_Txt;

    private int currentScore_Value = 0;
    private int highScore_Value = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        highScore_Value = PlayerPrefs.GetInt("highScore_Value", 0);
        currentScore_Txt.text = "Score: " + currentScore_Value.ToString();
        highScore_Txt.text = "High Score: " + highScore_Value.ToString();
    }

    public void AddPoint(int pointValue)
    {
        currentScore_Value += pointValue;
        currentScore_Txt.text = "Score: " + currentScore_Value.ToString();

        if (highScore_Value < currentScore_Value)
            PlayerPrefs.SetInt("highScore_Value", currentScore_Value);
    }
    public void MinusPoint(int pointValue)
    {
        currentScore_Value -= pointValue;
        currentScore_Txt.text = "Score: " + currentScore_Value.ToString();

        if (highScore_Value < currentScore_Value)
            PlayerPrefs.SetInt("highScore_Value", currentScore_Value);
    }
}

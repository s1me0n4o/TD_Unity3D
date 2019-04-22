using UnityEngine;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour
{
    public static int money;
    public int startMoney = 500;
    public GameObject MoneyUI;
    private Text moneyUI;

    public static int lives;
    public int startingLives = 100;

    public static int rounds;

    void Start()
    {
        lives = startingLives;
        money = startMoney;
        moneyUI = MoneyUI.GetComponent<Text>();
        rounds = 0;
    }

    void Update()
    {
        moneyUI.text = "$" + money.ToString();
    }

}

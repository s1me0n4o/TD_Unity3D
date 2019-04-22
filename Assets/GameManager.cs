using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text gameOverText;

    public static bool isOver;

    void Start()
    {
        isOver = false;
    }

    void Update()
    {
        if (isOver)
        {
            return;
        }

        if (PlayerStatistics.lives <= 0)
        {
            EndGame();
        }

        void EndGame()
        {
            isOver = true;
            gameOverText.text = PlayerStatistics.rounds.ToString() + " Waves Completed";
            gameOverUI.SetActive(true);
            print("GameOver");
        }

    }
}

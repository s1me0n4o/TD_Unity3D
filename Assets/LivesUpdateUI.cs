using UnityEngine;
using UnityEngine.UI;

public class LivesUpdateUI : MonoBehaviour
{

    public Text lives;

    // Update is called once per frame
    void Update()
    {
        lives.text = "REMAINING LIVES: " + PlayerStatistics.lives.ToString();
    }
}

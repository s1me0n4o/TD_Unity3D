using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string loadLevel = "SampleScene";

    public void Play()
    {
        print("Load the scene");
        SceneManager.LoadScene(loadLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputManagerMainMenu : MonoBehaviour
{
    


    public void Start()
    {
      
    }
    public void start()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void Exit()
    {
        Debug.Log("Quitting Game.");
        Application.Quit();
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NewGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

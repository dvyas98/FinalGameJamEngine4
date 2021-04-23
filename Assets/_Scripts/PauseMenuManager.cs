using UnityEngine;
using UnityEngine.InputSystem;


public class PauseMenuManager : MonoBehaviour
{
    public GameObject PauseCanavas;
    public static bool isGamePaused=false;
   


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
       PauseCanavas.SetActive(false);
    }

    void Update()
    {
        Keyboard kb = InputSystem.GetDevice<Keyboard>();
        
        if (kb.escapeKey.wasPressedThisFrame)
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        PauseCanavas.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
      //  Debug.Log(isGamePaused);
    }

    public void Resume()
    {
        PauseCanavas.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
       // Debug.Log(isGamePaused);

    }
}

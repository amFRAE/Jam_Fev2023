using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject HowtoPlayWindow1;
    public GameObject creditsWindow;
    public GameObject settingsWindow;
    public GameObject HowtoPlayWindow2;
    [SerializeField] private AudioSource buttonclick;

    public void StartGame()
    {
        buttonclick.Play();
        SceneManager.LoadScene(levelToLoad);
    }

    public void OpenHowtoPlayWindow()
    {
        buttonclick.Play();
        HowtoPlayWindow1.SetActive(true);
    }

    public void OpenCreditsWindow()
    {
        buttonclick.Play();
        creditsWindow.SetActive(true);
    }
    public void OpenSettingsWindow()
    {
        buttonclick.Play();
        settingsWindow.SetActive(true);
    }
    public void OpenNextPageHTP()
    {
        buttonclick.Play();
        HowtoPlayWindow2.SetActive(true);
        HowtoPlayWindow1.SetActive(false);
    }
    public void CloseNextPageHTP()
    {
        buttonclick.Play();
        HowtoPlayWindow2.SetActive(false);
    }
    public void ReturnPastPageHTP()
    {
        buttonclick.Play();
        HowtoPlayWindow2.SetActive(false);
        HowtoPlayWindow1.SetActive(true);
    }
    public void CloseHowtoPlayWindow()
    {
        buttonclick.Play();
        HowtoPlayWindow1.SetActive(false);
    }

    public void CloseCreditsWindow()
    {
        buttonclick.Play();
        creditsWindow.SetActive(false);
    }
    public void CloseSettingsWindow()
    {
        buttonclick.Play();
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        buttonclick.Play();
        Application.Quit();
    }
}

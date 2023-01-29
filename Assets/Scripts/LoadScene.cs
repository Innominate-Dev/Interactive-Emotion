using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject Dialogue;
    public GameObject PoemUI;
    public void SkipDialogue()
    {
        Dialogue.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ClosePoem()
    {
        PoemUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Prototyping");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }
    public void Retry()
    {
        SceneManager.LoadScene("Prototyping");
    }
    public void Quit()
    {
        Application.Quit();
    }
}

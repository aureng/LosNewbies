using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject UIPanel;
    public void OpenMenu()
    {
        Time.timeScale = 0;
        menuPanel.SetActive(true);
        UIPanel.SetActive(false);
    }
    public void CloseMenu()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
        UIPanel.SetActive(true);
    }
    public void Reiniciar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("frish");
    }
    public void Salir()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}

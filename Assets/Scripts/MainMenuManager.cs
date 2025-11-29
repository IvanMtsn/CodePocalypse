using System;
using UnityEditor.PackageManager;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject _homeScreen;
    [SerializeField] GameObject _settingsScreen;
    [SerializeField] GameObject _levelSelectScreen;
    void Start()
    {
        
    }
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !_homeScreen.activeSelf)
        {
            ReturnToMainMenu();
        }
    }
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ReturnToMainMenu()
    {
        _levelSelectScreen.SetActive(false);
        _settingsScreen.SetActive(false);

        _homeScreen.SetActive(true);
    }
    public void OpenLevelSelect()
    {
        _homeScreen.SetActive(false);
        _levelSelectScreen.SetActive(true);
    }
    public void OpenSettings()
    {
        _homeScreen.SetActive(false);
        _settingsScreen.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

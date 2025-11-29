using System;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject _homeScreen;
    [SerializeField] GameObject _settingsScreen;
    [SerializeField] GameObject _levelSelectScreen;
    [SerializeField] GameObject _videoSettings;
    [SerializeField] GameObject _audioSettings;
    [SerializeField] TMP_Dropdown _displayModeDropdown;
    void Start()
    {
        _displayModeDropdown.onValueChanged.AddListener(SetWindowMode);
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
    public void OpenVideoSettings()
    {
        _audioSettings.SetActive(false);
        _videoSettings.SetActive(true);
    }
    public void OpenAudioSettings()
    {
        _videoSettings.SetActive(false);
        _audioSettings.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void SetWindowMode(int index)
    {
        switch(index)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
        }
    }
}

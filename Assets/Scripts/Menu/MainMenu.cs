using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator levelPanel;

    private PrefsValue<int> currentLevel;
    private PrefsValue<bool> eternalMode;

    public void LoadLevel(int level)
    {
        currentLevel = new PrefsValue<int>("currentLevel", 0);
        eternalMode = new PrefsValue<bool>("eternalMode", false);

        eternalMode.Value = false;

        if (level != -1)
        {
            currentLevel.Value = level;
        }

        SceneManager.LoadScene(1);
    }
    public void LoadEternal()
    {
        eternalMode = new PrefsValue<bool>("eternalMode", false);

        eternalMode.Value = true;

        SceneManager.LoadScene(1);
    }
    public void OpenLevelPanel()
    {
        levelPanel.SetTrigger("Open");
    }
    public void CloseLevelPanel()
    {
        levelPanel.SetTrigger("Cllose");
    }
}

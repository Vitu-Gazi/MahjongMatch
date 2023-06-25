using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;

    [SerializeField] private bool randomLevel;
    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    private PrefsValue<int> currentLevel;


    private void Start()
    {
        if (randomLevel)
        {
            Instantiate(levels.GetRandom());
            return;
        }

        currentLevel = new PrefsValue<int>("currentLevel", 0);
        Instantiate(levels[currentLevel.Value]);
    }


    public void EndGame(bool value)
    {
        if (value)
        {
            if (currentLevel.Value < levels.Count - 1)
            {
                currentLevel.Value += 1;
            }

            winPanel.SetActive(true);
        }
        else
        {
            losePanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

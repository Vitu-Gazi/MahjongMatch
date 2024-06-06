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

    private GameObject level;

    private PrefsValue<int> currentLevel;
    private PrefsValue<bool> eternalMode;


    private void Start()
    {
        eternalMode = new PrefsValue<bool>("eternalMode", false);

        if (eternalMode.Value)
        {
            Instantiate(levels.GetRandom());
            return;
        }

        currentLevel = new PrefsValue<int>("currentLevel", 0);
        level = Instantiate(levels[currentLevel.Value]);
    }


    public void EndGame(bool value)
    {
        if (value)
        {
            if (!eternalMode.Value && currentLevel.Value < levels.Count - 1)
            {
                PrefsValue<string> cell = new PrefsValue<string>("cellState" + currentLevel.Value, CellState.LOCK.ToString());
                cell.Value = CellState.COMPLEATE.ToString();

                currentLevel.Value += 1;
            }

            if (!eternalMode.Value)
            {
                winPanel.SetActive(true);
            }
            else
            {
                Destroy(level);

                level = Instantiate(levels.GetRandom());
            }
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

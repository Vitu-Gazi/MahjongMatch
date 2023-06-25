using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private Transform[] positions;

    private List<Cell> cells = new List<Cell>();
    private List<Cell> similarCells = new List<Cell>();

    public List<Cell> Cells => cells;

    private void Start()
    {
        cells.Clear();
        similarCells.Clear();
    }
    public void AddCube(Cell cube)
    {
        similarCells.Clear();
        similarCells.Add(cube);

        foreach (Cell c in cells)
        {
            if (c.CurrentSprite == cube.CurrentSprite)
            {
                similarCells.Add(c);
                if (similarCells.Count >= 3)
                {
                    foreach (Cell sim in similarCells)
                    {
                        cells.Remove(sim);
                        Destroy(sim.gameObject);
                    }
                    similarCells.Clear();

                    for (int i = 0; i < cells.Count; i++)
                    {
                        cells[i].transform.DOMove(positions[i].position, 0.5f).SetEase(Ease.Linear);
                    }
                    return;
                }
            }
        }

        cells.Add(cube);
        cube.transform.SetParent(null);
        cube.transform.DOMove(positions[cells.Count - 1].position, 0.3f);
        cube.transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), 0.3f);


        if (cells.Count >= 7)
        {
            GameController.Instance.EndGame(false);
        }
    }
}

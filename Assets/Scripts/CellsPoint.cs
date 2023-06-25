using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellsPoint : MonoBehaviour
{
    private List<Cell> cells = new List<Cell>();

    public int Count => cells.Count;

    private void Start()
    {
        Cell.TryRemoveCell += TryRemoveCell;
    }
    private void OnDisable()
    {
        Cell.TryRemoveCell -= TryRemoveCell;
    }

    public void AddCell(Cell newCell)
    {
        cells.Add(newCell);
    }

    private void TryRemoveCell(Cell newCell)
    {
        if (cells.Count > 0)
        {
            if (newCell.gameObject == cells.Last().gameObject)
            {
                cells.Remove(newCell);
                Inventory.Instance.AddCube(newCell);
            }
        }

        if (cells.Count == 0)
        {
            PointsController.CheckEndGame.Invoke();
        }
    }
}

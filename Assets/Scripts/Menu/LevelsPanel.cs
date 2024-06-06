using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField] private List<LevelCell> cells;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        PrefsValue<string> cellState;
        for (int c = 0; c < cells.Count; c++)
        {
            if (c == 0)
            {
                cellState = new PrefsValue<string>("cellState" + c, CellState.UNLOCK.ToString());

                cells[c].InitCell((CellState)Enum.Parse(typeof(CellState), cellState.Value));
            }
            else
            {
                cellState = new PrefsValue<string>("cellState" + c, CellState.LOCK.ToString());

                if ((CellState)Enum.Parse(typeof(CellState), cellState.Value) == CellState.COMPLEATE)
                {
                    cells[c].InitCell((CellState)Enum.Parse(typeof(CellState), cellState.Value));
                    continue;
                }


                cellState = new PrefsValue<string>("cellState" + (c - 1), CellState.LOCK.ToString());

                Debug.Log("VALUE " + cellState.Value);


                if ((CellState)Enum.Parse(typeof(CellState), cellState.Value) == CellState.COMPLEATE)
                {
                    cellState = new PrefsValue<string>("cellState" + c, CellState.LOCK.ToString());
                    cellState.Value = CellState.UNLOCK.ToString();

                    cells[c].InitCell((CellState)Enum.Parse(typeof(CellState), cellState.Value));
                }
            }
        }
    }
}

public enum CellState
{
    LOCK,
    UNLOCK,
    COMPLEATE
}

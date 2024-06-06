using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCell : MonoBehaviour
{
    [SerializeField] private GameObject lockImage;

    public void InitCell (CellState cellState)
    {
        if (cellState != CellState.LOCK)
        {
            lockImage.SetActive(false);
        }
    }
}

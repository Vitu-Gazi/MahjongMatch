using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] private List<CellsPoint> points;

    public static Action CheckEndGame;

    private void Start()
    {
        CheckEndGame += CheckPoints;
    }
    private void OnDisable()
    {
        CheckEndGame -= CheckPoints;
    }

    private void CheckPoints ()
    {
        foreach (CellsPoint point in points)
        {
            if (point.Count > 0)
            {
                return;
            }
        }

        GameController.Instance.EndGame(true);
    }
}

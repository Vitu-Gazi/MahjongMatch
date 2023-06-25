using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private int cellsNumber;

    [SerializeField] private Cell prefab;

    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    [SerializeField] private List<CellsPoint> points = new List<CellsPoint>();

    private List<Cell> cells = new List<Cell>();

    private int lastLevel = 0;

    private void Start()
    {
        Init();
    }


    private void Init ()
    {
        Generate();
        Randomizer();
    }


    private void Generate()
    {
        int currentLevel = 0;
        int currentCell = 0;

        for (int i = 0; i < cellsNumber; i++)
        {
            for (int c = 0; c < 3; c++)
            {
                Cell cell = Instantiate(prefab);

                cell.SetSprite(sprites[i]);
                cell.Level = currentLevel;

                points[currentCell].AddCell(cell);

                Vector3 pos = points[currentCell].transform.position;
                pos.y -= (currentLevel * 0.08f);
                pos.z -= (currentLevel * 0.01f);
                cell.transform.position = pos;

                currentCell++;
                cells.Add(cell);

                if (currentCell == points.Count)
                {
                    currentCell = 0;
                    currentLevel++;

                    lastLevel = currentLevel;
                }
            }
        }
    }



    private void Randomizer()
    {
        List<Cell> levelCells = new List<Cell>();

        int level = 0;

        while (cells.Count > 0)
        {
            foreach (var cell in cells)
            {
                if (cell.Level == level || cell.Level == level + 1)
                {
                    levelCells.Add(cell);
                }
            }

            cells = cells.Except(levelCells).ToList();

            while (levelCells.Count > 1)
            {
                Cell cellOne = levelCells.GetRandom();
                Sprite spriteOne = cellOne.CurrentSprite;
                levelCells.Remove(cellOne);

                Cell cellTwo = levelCells.GetRandom();
                Sprite spriteTwo = cellTwo.CurrentSprite;
                levelCells.Remove(cellTwo);

                cellOne.SetSprite(spriteTwo);
                cellTwo.SetSprite(spriteOne);
            }

            if (level + 2 <= lastLevel)
            {
                level += 2;
            }
            else
            {
                level++;
            }
        }
        
    }
}

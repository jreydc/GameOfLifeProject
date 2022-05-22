using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private GridData _gridData;
    private GridAttrib _gridAttrib;
    private CellData _cell;
    Cell[,] grid;

    public void CreateEmptyGrid(int width, int height){
        grid = new Cell[width, height];
    }

    public void CellManagement(){
        Cell cell_instance;
        //Setting up Cells
        for(int y = 0; y < grid.GetLength(0); y++){
            for(int x = 0; x < grid.GetLength(1); x++){
                cell_instance = Instantiate(Resources.Load("Prefab/Cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                grid[x, y] = cell_instance;
                cell_instance.SetAlive(RandomAliveCell());
            }
        }
    }

    private bool RandomAliveCell(){
    int rand = UnityEngine.Random.Range(0, 100);
    if (rand > 75){
        return true;
    }

    return false;
    }
}

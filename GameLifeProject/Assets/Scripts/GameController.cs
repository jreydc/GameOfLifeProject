using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private ManagedGridData _gridManaged;  

    private GridData _gridData;
    private GridAttrib _gridAttrib;
    private CellData _cell;
    Cell[,] grid = new Cell[width, height];

    
    public void CellManagement(){
        Cell cell_instance;
        //Setting up Cells
        for(int x = 0; x < grid.GetLength(0); x++){
            for(int y = 0; y < grid.GetLength(1); y++){
                cell_instance = Instantiate(Resources.Load("Prefab/Cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                grid[x, y] = cell_instance;
                cell_instance.SetAlive(RandomAliveCell());
            }
        }
    }

}

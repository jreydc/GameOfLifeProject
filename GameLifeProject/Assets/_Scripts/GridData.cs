using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData : MonoBehaviour
{
    public static GridData  _gridDataInstance;
    public GridAttrib _gridAttrib;
    private Cell[,] grid;
    private GameObject[,] tilemap;
    private Cell cell_instance;
    
    public void GridCreation(int rows, int cols){
        grid = new Cell[rows, cols];
        _gridAttrib.width = rows;
        _gridAttrib.height = cols;
        Debug.Log("Grid Creation"+_gridAttrib.width+"-"+_gridAttrib.height);
    }

    public void CellManagement(int rows, int cols){
        //GameObject tile_instance;
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                cell_instance = Instantiate(Resources.Load("Prefab/Cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                //tile_instance = Instantiate(Resources.Load("Prefab/Tile", typeof(GameObject)), new Vector2(x, y), Quaternion.identity) as GameObject;
                //tilemap[x, y] = tile_instance;
                grid[x, y] = cell_instance;
                cell_instance.cellInfo.x = x;
                cell_instance.cellInfo.y = y;
                cell_instance.SetAlive(RandomAliveCell());   
            }
        }
        Debug.Log("Cell Inputs");
    }
    public void Neighbours(){
        for (int x = 0; x < _gridAttrib.width; x++)
        {
            for (int y = 0; y < _gridAttrib.height; y++)
            {
                int total = 0;
                total = ComputingNeighbours(x, y);
                grid[x,y].NumNeighbours = total;    
            }
            
        }
    }

    private int ComputingNeighbours(int x, int y){
        int sum = 0;
        if (grid[x, y].cellInfo.x < 1){
            x = 1;
        }else if(grid[x, y].cellInfo.x >= _gridAttrib.width){
            x = _gridAttrib.width - 1;
        }else if(grid[x, y].cellInfo.y < 1){
            y = 1;
        }else if(grid[x, y].cellInfo.y >= _gridAttrib.height){
            y = _gridAttrib.height - 1;
        }else{
            grid[x, y].cellInfo.x = x;
            grid[x, y].cellInfo.y = y;
        }

        for(int i = -1; i < 2; i++){
            for(int j = -1; j < 2; j++){
                x = (grid[x,y].cellInfo.x + i + _gridAttrib.width) % _gridAttrib.width;
                y = (grid[x,y].cellInfo.y + j + _gridAttrib.height) % _gridAttrib.height;
            
                cell_instance = grid[x,y];
                if (cell_instance.GetComponent<Cell>().IsAlive){
                    sum+=1;
                }
            }
        }  
        return sum;
    }

    public void PopulationControl(){
        for (int x = 0; x < _gridAttrib.width; x++)
        {
            for (int y = 0; y < _gridAttrib.height; y++)
            {
                cell_instance = grid[x, y];
                if (!cell_instance.IsAlive && (cell_instance.NumNeighbours == 3)){
                    cell_instance.SetAlive(true);
                }else if (cell_instance.IsAlive && (cell_instance.NumNeighbours < 2 || cell_instance.NumNeighbours > 3)){
                    cell_instance.SetAlive(false);
                }else{
                    cell_instance.SetAlive(cell_instance.IsAlive);
                }
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

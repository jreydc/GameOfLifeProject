using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Grid", fileName = "GridModel")]
public class GridData : ScriptableObject
{
    public static GridData  _gridDataInstance;
    public GridAttrib _gridAttrib;
    private Cell[,] grid;

    private Cell cell_instance;
    
    public void GridCreation(int rows, int cols){
        grid = new Cell[rows, cols];
        _gridAttrib.width = rows;
        _gridAttrib.height = cols;
        Debug.Log("Grid Creation"+_gridAttrib.width+"-"+_gridAttrib.height);
    }

    public void CellManagement(int rows, int cols){
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                cell_instance = Instantiate(Resources.Load("Prefab/Cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                grid[x, y] = cell_instance;
                cell_instance.cellInfo.x = x;
                cell_instance.cellInfo.y = y;
                cell_instance.SetAlive(RandomAliveCell());   
            }
        }
        //Debug.Log("Cell Inputs");
    }
    public void Neighbours(){
        for (int x = 0; x < _gridAttrib.width; x++)
        {
            for (int y = 0; y < _gridAttrib.height; y++)
            {
                /* total = ComputingNeighbours(x, y);
                grid[x,y].NumNeighbours = total;
                //Debug.Log(x+"-"+y);  */

                //other algorithm for GOL
                int totalNeighbors = 0;
                //North
                if (y + 1 < _gridAttrib.height){
                    if (grid[x, y + 1].IsAlive)
                    {
                        totalNeighbors++;
                    }
                }
                //East
                if (x + 1 < _gridAttrib.width){
                    if (grid[x + 1, y].IsAlive)
                    {
                        totalNeighbors++;
                    }

                }
                //South
                if (y - 1 >= 0){
                    if (grid[x, y - 1].IsAlive)
                    {
                        totalNeighbors++;
                    }
                }
                //West
                if (x - 1 >= 0){
                    if (grid[x - 1, y].IsAlive)
                    {
                        totalNeighbors++;
                    }
                }
                //North East
                if (x + 1 < _gridAttrib.width && y + 1 < _gridAttrib.height){
                    if (grid[x + 1, y + 1].IsAlive)
                    {
                        totalNeighbors++;
                    }
                }
                //North West
                if (x - 1 >= 0 && y + 1 < _gridAttrib.height){
                    if (grid[x - 1, y + 1].IsAlive)
                    {
                        totalNeighbors++;
                    }
                }
                //SouthEast
                if (x + 1 < _gridAttrib.width && y - 1 >= 0){
                    if (grid[x + 1, y - 1].IsAlive)
                    {
                        totalNeighbors++;
                    }
                }
                //SouthWest
                if (x - 1 >= 0 && y - 1 >= 0){
                    if (grid[x - 1, y - 1].IsAlive)
                    {
                        totalNeighbors++;
                    }
                }
                grid[x, y].NumNeighbours = totalNeighbors;
            }
            
        }
    }

    private int ComputingNeighbours(int x, int y){
        int sum = 0;
        cell_instance = grid[x,y];
        Debug.Log(x+"-"+y);    
        for(int i = -1; i < 2; i++){
            for(int j = -1; j < 2; j++){
                x = (cell_instance.cellInfo.x + i + _gridAttrib.width) % _gridAttrib.width;
                y = (cell_instance.cellInfo.y + j + _gridAttrib.height) % _gridAttrib.height;
                            
                if (cell_instance.IsAlive){
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
                //-Rules
                //Any live cell with fewer than two live neighbours dies, as if by underpopulation.
                //Any live cell with two or three live neighbours lives on to the next generation.
                //Any live cell with more than three live neighbours dies, as if by overpopulation.
                //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
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

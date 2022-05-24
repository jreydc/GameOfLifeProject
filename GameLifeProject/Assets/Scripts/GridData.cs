﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData : MonoBehaviour
{
    public GridAttrib _gridAttrib;
    private Cell[,] grid;
    private GameObject[,] tilemap;
    private Cell cell_instance;
    
    public void GridCreation(int rows, int cols){
        grid = new Cell[rows, cols];
        _gridAttrib.width = rows;
        _gridAttrib.height = cols;
        Debug.Log("Grid Creation");
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
        Cell cell_instance;
        for(int i = -1; i < 2; i++){
            for(int j = -1; j < 2; j++){
                x = (x + i + _gridAttrib.width) % _gridAttrib.width;
                y = (y + j + _gridAttrib.height) % _gridAttrib.height;

                cell_instance = grid[x,y];
                if (cell_instance.GetComponent<Cell>().IsAlive){
                    sum++;
                }
                Debug.Log(cell_instance+"-"+ x +"-"+y);
            }
        }  
        return sum;
    }
    private bool RandomAliveCell(){
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand > 75){
            return true;
        }
        return false;
    }
}

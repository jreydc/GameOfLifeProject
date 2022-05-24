using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    GameObject[,] grid;
    GameObject[,] nextGrid;
    
    private int rows = 20;
    private int cols = 20;


    // Start is called before the first frame update
    void Awake()
    {
        grid = CreateGrid(rows, cols);
    }

    private void Start() {
        SetupCell(rows, cols); 
    }

    // Update is called once per frame
    void Update()
    {
        Neighbours(rows, cols);
        PopulationControl();
    }

    private GameObject[,] CreateGrid(int rows, int cols){
        grid = new GameObject[rows, cols];
        return grid;
    }

    private void SetupCell(int rows, int cols){
        GameObject referenceCell = (GameObject)Instantiate(Resources.Load("Prefab/Cell"));
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                GameObject cell_instance = Instantiate(referenceCell, new Vector2(i, j), Quaternion.identity);
                cell_instance.GetComponent<Cell>().SetAlive(RandomAliveCell());
                grid[i, j] = cell_instance;   
            }
        }
        nextGrid = grid;
        Destroy(referenceCell);
    }

    private void Neighbours(int rows, int cols){
        for (int x = 0; x < rows; x++)//cols = 64
        {
            for (int y = 0; y < cols; y++)//rows = 48
            {
                int total = 0;
                total = ComputingNeighbours(x, y);
                grid[x,y].GetComponent<Cell>().NumNeighbours = total;    
            }
            
        }
    }

    private int ComputingNeighbours(int x, int y){
        int sum = 0;
        GameObject cell_instance;
        for(int i = -1; i < 2; i++){
            for(int j = -1; j < 2; j++){
                x = (x + i + rows) % rows;
                y = (y + j + cols) % cols;

                cell_instance = grid[x,y];
                if (cell_instance.GetComponent<Cell>().IsAlive){
                    sum++;
                }
                Debug.Log(cell_instance+"-"+ x +"-"+y);
            }
        }  
        return sum;
    }

    private void PopulationControl(){
        for (int x = 0; x < rows; x++)//cols = 64
        {
            for (int y = 0; y < cols; y++)//rows = 48
            {
                Cell cell_instance = grid[x, y].GetComponent<Cell>();
                if (!cell_instance.IsAlive && (cell_instance.NumNeighbours == 3)){
                    cell_instance.SetAlive(true);
                }else if (cell_instance.IsAlive && (cell_instance.NumNeighbours < 2 || cell_instance.NumNeighbours > 3)){
                    cell_instance.SetAlive(false);
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

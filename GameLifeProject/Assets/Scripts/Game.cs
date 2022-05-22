using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static int SCREEN_WIDTH = 64;
    private static int SCREEN_HEIGHT = 48;
    // Start is called before the first frame update
    Cell[,] grid = new Cell[SCREEN_WIDTH, SCREEN_HEIGHT];

    void Start()
    {  
        PlaceCells();
    }

    private void PlaceCells(){
        Cell cell_instance;
        //Setting up Cells
        for(int y = 0; y < SCREEN_HEIGHT; y++){
            for(int x = 0; x < SCREEN_WIDTH; x++){
                cell_instance = Instantiate(Resources.Load("Prefab/Cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                grid[x, y] = cell_instance;
                cell_instance.gameObject.SetActive(RandomAliveCell());
            }
        }
    }

    bool RandomAliveCell(){
        int rand = UnityEngine.Random.Range(0, 100);

        if (rand > 75){
            return true;
        }

        return false;
    }
}

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

   void Update() {
        CountNeighbours();
    }

    private void PlaceCells(){
        Cell cell_instance;
        //Setting up Cells
        for(int y = 0; y < SCREEN_HEIGHT; y++){
            for(int x = 0; x < SCREEN_WIDTH; x++){
                cell_instance = Instantiate(Resources.Load("Prefab/Cell", typeof(Cell)), new Vector2(x, y), Quaternion.identity) as Cell;
                grid[x, y] = cell_instance;
                cell_instance.SetAlive(RandomAliveCell());
            }
        }
    }

    void CountNeighbours(){
        for(int y = 0; y < SCREEN_HEIGHT; y++){
            for(int x = 0; x < SCREEN_WIDTH; x++){
                int total = ComputingNeighbours(x, y);
                 /* //North
                if (y + 1 < SCREEN_HEIGHT){
                    if(grid[x,y + 1].IsAlive){
                        total+=1;
                    }
                }
                //East
                if(x + 1 < SCREEN_WIDTH){
                    if(grid[x + 1, y].IsAlive){
                        total+=1;
                    }
                }
                //South
                if (y - 1 >= 0){
                    if(grid[x,y - 1].IsAlive){
                        total+=1;
                    }
                }
                //West
                if(x - 1 >= 0){
                    if(grid[x - 1, y].IsAlive){
                        total+=1;
                    }
                }
                //NorthEast
                if(x + 1 < SCREEN_WIDTH && y + 1 < SCREEN_HEIGHT){
                    if(grid[x - 1, y + 1].IsAlive){
                        total+=1;
                    }    
                }
                //NorthWest
                if(x - 1 >= 0 && y + 1 < SCREEN_HEIGHT){
                    if(grid[x - 1, y + 1].IsAlive){
                        total+=1;
                    }    
                }
                //SouthEast
                if(x + 1 < SCREEN_WIDTH && y - 1 >= 0){
                    if(grid[x + 1, y - 1].IsAlive){
                        total+=1;
                    }
                }
                //SouthWest
                if(x - 1 >= 0 && y - 1 >= 0){
                    if(grid[x - 1, y - 1].IsAlive){
                        total+=1;
                    }    
                }   */
                
                Debug.Log(total+""+ x+""+ y);
                grid[x, y].NumNeighbours = total;
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

    private int ComputingNeighbours(int x, int y){
        int sum = 0;
        for(int i = -1; i < 2; i++){
            for(int j = -1; j < 2; j++){
                if (grid[x+i,y+j].IsAlive){
                    sum++;
                }
            }
        }

        return sum;
    }
}

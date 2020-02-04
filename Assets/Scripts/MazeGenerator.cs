using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    static public int height = 20;
    static public int width = 20;
    static public int[,] maze;
    public GameObject Walls;
    public GameObject StartPos;
    public GameObject FinishPos;
    public GameObject Player;
    public GameObject Slime;
    static public List<GameObject> wallsList = new List<GameObject>();
    static public int startRow;
    static public int startCol;
    static public int finishRow;
    static public int finishCol;
    void Start()
    {
        generateMaze();
        buildMaze();
        generateStartAndFinish();
        createPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void generateMaze()
    {
        maze = new int[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                maze[i, j] = 1;
            }
        }

        //Generate random starting position. 
        int row = Random.Range(1, height);
        while (row % 2 == 0)
        {
            row = Random.Range(1, height);
        }
        startRow = row;

        int col = Random.Range(1, width);
        while (col % 2 == 0)
        {
            col = Random.Range(1, width);
        }
        startCol = col;

        maze[row, col] = 0;
        buildMazeLayout(row, col);

    }
    void buildMazeLayout(int row, int col)
    {
        //randomize the directions for the maze
        List<int> directions = new List<int>();
        directions.Add(1); directions.Add(2); directions.Add(3); directions.Add(4);
        List<int> randomDirections = new List<int>();
        int randomIndex = 0;
        while (directions.Count > 0)
        {
            randomIndex = Random.Range(0, directions.Count);
            randomDirections.Add(directions[randomIndex]);
            directions.RemoveAt(randomIndex);
        }
        
        for (int i = 0; i < randomDirections.Count; i++)
        {
            switch (randomDirections[i])
            {
                case 1: //Up direction
                    if (row - 2 <= 0) continue;
                    if (maze[row - 2, col] != 0)
                    {
                        maze[row - 2, col] = 0;
                        maze[row - 1, col] = 0;
                        buildMazeLayout(row - 2, col);
                    }
                    break;
                case 2: //Right direction
                    if (col + 2 >= width - 1) continue;
                    if (maze[row, col + 2] != 0)
                    {
                        maze[row, col + 2] = 0;
                        maze[row, col + 1] = 0;
                        buildMazeLayout(row, col + 2);
                    }
                    break;
                case 3: //Down direction
                    if (row + 2 >= height - 1) continue;
                    if (maze[row + 2, col] != 0)
                    {
                        maze[row + 2, col] = 0;
                        maze[row + 1, col] = 0;
                        buildMazeLayout(row + 2, col);
                    }
                    break;
                case 4: //Left direction
                    if (col - 2 <= 0) continue;
                    if (maze[row, col - 2] != 0)
                    {
                        maze[row, col - 2] = 0;
                        maze[row, col - 1] = 0;
                        buildMazeLayout(row, col - 2);
                    }
                    break;
            }
        }
    }

    void buildMaze()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (maze[i,j] == 1)
                {
                    GameObject singleWall = Instantiate(Walls, new Vector3(((height/2 - 0.5f) * -1f) + i, 0.5f, ((width / 2 - 0.5f) * -1f) + j), Quaternion.identity);
                    wallsList.Add(singleWall);
                }
            }
        }

    }

    void generateStartAndFinish()
    {
        finishRow = Random.Range(1, height);
        finishCol = Random.Range(1, width);
        while (maze[finishRow, finishCol] != 0)
        {
            finishRow = Random.Range(1, height);
            finishCol = Random.Range(1, width);
        }
        Instantiate(StartPos, new Vector3(((height / 2 - 0.5f) * -1f) + startRow, 0.0f, ((width / 2 - 0.5f) * -1f) + startCol), Quaternion.identity);
        Instantiate(FinishPos, new Vector3(((height / 2 - 0.5f) * -1f) + finishRow, 0.0f, ((width / 2 - 0.5f) * -1f) + finishCol), Quaternion.identity);
    }

    void createPlayer()
    {
        GameObject player = Instantiate(Player, new Vector3(((height / 2 - 0.5f) * -1f) + startRow, 0.0f, ((width / 2 - 0.5f) * -1f) + startCol), Quaternion.identity);
        GameObject slime = Instantiate(Slime, new Vector3(((height / 2 - 0.5f) * -1f) + startRow, 0.0f, ((width / 2 - 0.5f) * -1f) + startCol), Quaternion.identity);
    }

}
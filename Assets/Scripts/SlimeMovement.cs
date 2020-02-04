using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SlimeMovement : MonoBehaviour
{ 

    int startRow;
    int startCol;
    int finishRow;
    int finishCol;
    int currRow;
    int currCol;
    int nextRow;
    int nextCol;
    int difficulty = StartGame.difficulty;
    Vector3 finishPos = new Vector3(((MazeGenerator.height / 2 - 0.5f) * -1f) + MazeGenerator.finishRow, 0.0f, ((MazeGenerator.width / 2 - 0.5f) * -1f) + MazeGenerator.finishCol);
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        startRow = MazeGenerator.startRow;
        startCol = MazeGenerator.startCol;
        currRow = startRow;
        currCol = startCol;
        finishRow = MazeGenerator.finishRow;
        finishCol = MazeGenerator.finishCol;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        int value = UnityEngine.Random.Range(1, difficulty);
        if (value == difficulty - 1)
        {
            getMove();
            makeMove();
            checkWin();
        }
    }

    void getMove()
    {
        bool movePicked = false;
        while (!movePicked)
        {
            int i = UnityEngine.Random.Range(1, 5);
            if (i == 1)
            {
                if (MazeGenerator.maze[currRow, currCol - 1] == 0)
                {
                    movePicked = true;
                    nextRow = currRow;
                    nextCol = currCol - 1;
                }
            }
            if (i == 2)
            {
                if (MazeGenerator.maze[currRow, currCol + 1] == 0)
                {
                    movePicked = true;
                    nextRow = currRow;
                    nextCol = currCol + 1;
                }
            }
            if (i == 3)
            {
                if (MazeGenerator.maze[currRow - 1, currCol] == 0)
                {
                    movePicked = true;
                    nextRow = currRow - 1;
                    nextCol = currCol;
                }
            }
            if (i == 4)
            {
                if (MazeGenerator.maze[currRow + 1, currCol] == 0)
                {
                    movePicked = true;
                    nextRow = currRow + 1;
                    nextCol = currCol;
                }
            }
        }
    }

    void makeMove()
    {
        Vector3 position = new Vector3(((MazeGenerator.height / 2 - 0.5f) * -1f) + nextRow, 0.5f, ((MazeGenerator.width / 2 - 0.5f) * -1f) + nextCol);
        transform.position = position;
        currCol = nextCol;
        currRow = nextRow;
    }

    void checkWin()
    {
        float d = (float)Math.Sqrt(((position.x - finishPos.x) * (position.x - finishPos.x)) + ((position.z - finishPos.z) * (position.z - finishPos.z)));
        if (d < 0.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

}

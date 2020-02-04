using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float delta_t = 0.1f;
    public bool camSwitch = false;
    Vector3 position;
    // Start is called before the first frame update
    Vector3 startPos;
    Vector3 finishPos = new Vector3(((MazeGenerator.height / 2 - 0.5f) * -1f) + MazeGenerator.finishRow, 0.0f, ((MazeGenerator.width / 2 - 0.5f) * -1f) + MazeGenerator.finishCol);
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //inputX = Input.GetAxis("Horizontal");
        position = transform.position;

        //Body Motion
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.forward * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 5, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -5, 0, Space.World);
        }

        //Wall Collision
        foreach(GameObject wall in MazeGenerator.wallsList)
        {
            Vector3 wall_position = wall.transform.position;
            float d = (float)Math.Sqrt( ((position.x - wall_position.x) * (position.x - wall_position.x)) + ((position.z - wall_position.z) * (position.z - wall_position.z)) );
            if (d < 0.55f)
            {
                position.x = wall_position.x + (0.6f * (position.x - wall_position.x) / d);
                position.z = wall_position.z + (0.6f * (position.z - wall_position.z) / d);
                transform.position = position;
            }

        }

        checkFinish();
    }

    void checkFinish()
    {
        float d = (float)Math.Sqrt(((position.x - finishPos.x) * (position.x - finishPos.x)) + ((position.z - finishPos.z) * (position.z - finishPos.z)));
        if (d < 0.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

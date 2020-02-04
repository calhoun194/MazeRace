using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainCamera;
    public GameObject TopView;
    bool camActive = true;
    void Start()
    {
        MainCamera.SetActive(camActive);
        TopView.SetActive(!camActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            camActive = !camActive;
            MainCamera.gameObject.SetActive(camActive);
            TopView.gameObject.SetActive(!camActive);
        }
    }
}

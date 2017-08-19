using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }
    public void PressButton_GG(int number)
    {

        switch (number)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Boxing",UnityEngine.SceneManagement.LoadSceneMode.Single);
                break;
        }
    }
}

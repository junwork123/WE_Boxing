using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton: MonoBehaviour
{
    public void Retry()
    {
       UnityEngine.SceneManagement.SceneManager.LoadScene("Boxing",UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}

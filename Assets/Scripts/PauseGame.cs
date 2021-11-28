using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;

    public void PauseHandler()
    {
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}

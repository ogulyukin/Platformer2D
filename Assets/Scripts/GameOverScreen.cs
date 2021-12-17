using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RetartHandler()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitHandler()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}

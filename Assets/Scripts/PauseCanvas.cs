using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    public void continurHandler()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

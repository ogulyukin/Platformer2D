using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private bool isActivated = false;

    public void FinishLever()
    {
        if(isActivated)
            gameObject.SetActive(false);
    }

    public void ActivateFinish()
    {
        isActivated = true;
    }
}

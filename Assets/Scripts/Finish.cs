using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject messageUI;

    private bool _isActivated = false;

    public void FinishLever()
    {
        if(_isActivated)
        {
            gameObject.SetActive(false);
        }else
        {
            messageUI.SetActive(true);
        }
    }

    public void ActivateFinish()
    {
        _isActivated = true;
        messageUI.SetActive(false);
    }
}

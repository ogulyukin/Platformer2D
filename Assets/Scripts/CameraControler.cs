using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(playerController.transform.position.x, playerController.transform.position.y, transform.position.z);
    }
}

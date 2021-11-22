using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowingCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private void LateUpdate()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
    }
}

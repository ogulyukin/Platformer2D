using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowingCamera : MonoBehaviour
{
    [SerializeField] private Camera _cam;

    private void LateUpdate()
    {
        _cam.transform.position = new Vector3(transform.position.x, transform.position.y, _cam.transform.position.z);
    }
}

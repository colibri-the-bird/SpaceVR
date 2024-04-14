using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Start : MonoBehaviour
{
    public LineRenderer line;

    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        UnityEngine.Debug.DrawRay(ray.origin, ray.direction);
    }
}

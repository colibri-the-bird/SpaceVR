
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shroomp1 : MonoBehaviour
{
    // Start is called before the first frame update
    private float time;
    public float k;
    public float a;
    void Update()
    {
        time += Time.deltaTime;
        this.gameObject.transform.Rotate(new Vector3(Mathf.Cos(time * Mathf.PI / a) / k, 0,0));
    }
}

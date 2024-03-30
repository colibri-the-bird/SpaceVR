using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ef_script : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem[] ps;
    private int k;


    void Start()
    {
        ps[k].Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ps[k].isPlaying)
        {
            if (k == 0) k = 1;
            else k = 0;
            ps[k].Play();
        }
    }
}

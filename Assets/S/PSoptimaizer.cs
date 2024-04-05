using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PSoptimaizer : MonoBehaviour
{
    public float R;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StttCoroutine());
    }

    private IEnumerator StttCoroutine()
    {
        var ParticleSystems = FindObjectsOfType<ParticleSystem>();
        foreach (var p in ParticleSystems)
        {
            if (p.gameObject.tag != "Fog") p.gameObject.SetActive(false);
        }
        while (true)
        {
            foreach (var particle in ParticleSystems)
            {
                if (particle.gameObject.tag != "Fog")
                {
                    if ((Mathf.Abs(this.transform.position.x - particle.transform.position.x) <= R) && (Mathf.Abs(this.transform.position.z - particle.transform.position.z) <= R))
                    {
                        particle.gameObject.SetActive(true);
                    }
                    else
                    {
                        particle.gameObject.SetActive(false);
                    }
                }
            }
            yield return new WaitForSeconds(Time.deltaTime * 10);
        }
    }
}

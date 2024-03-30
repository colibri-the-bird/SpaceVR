using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnarScript : MonoBehaviour
{


    public float life_T;
    public float Dmg_T;
    public float K;
    public float[] eff1;
    public float[] eff2;
    public int S_type;

    private bool started;

    private bool enemy_coll = false;


    public GameObject[] effs;


    void Update()
    {
        
    }

    public void StartSim()
    {
        StartCoroutine(StCoroutine());
    }
    void OnCollisionEnter(Collision collision)
    {
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        Destroy(this.gameObject.GetComponent<MeshRenderer>());
        Destroy(this.gameObject.GetComponent<Collider>());
        if (collision.gameObject.GetComponent<Enemy>() != null) enemy_coll = true;
        if ((!started) && ((S_type == 1)|(S_type == 2))) StEffect();
    }
    private IEnumerator StCoroutine()
    {
        yield return new WaitForSeconds(life_T);
        if (!started) StEffect();

    }

    public void StEffect()
    {
        started = true;
        if (eff1[0] == 7) Boom_eff(1, 1);
        if (eff1[0] == 4) Water_ef(1, 1);
        if (eff1[0] == 3) El_bolt(1, 1);
        if (eff1[0] == 1) Gravitat_eff(1, 1);
        if (eff1[0] == 8) Void_eff(1, 1);
        if (eff1[0] == 5) Life_eff(1, 1);
        if (eff1[0] == 6) Death_eff(1, 1);
        if (eff1[0] == 2) Metal_eff(1, 1);

        if (eff2[0] == 7) Boom_eff(0.5f, 2);
        if (eff2[0] == 4) Water_ef(0.5f, 2);
        if (eff2[0] == 3) El_bolt(0.5f, 2);
        if (eff2[0] == 1) Gravitat_eff(0.5f, 2);
        if (eff2[0] == 8) Void_eff(0.5f, 2);
        if (eff2[0] == 5) Life_eff(0.5f, 2);
        if (eff2[0] == 6) Death_eff(0.5f, 2);
        if (eff2[0] == 2) Metal_eff(0.5f, 2);
        Destroy(this.gameObject);
    }


    //===========================================================================================================
    private void Boom_eff(float m, int ef)
    {
        var clone = Instantiate(effs[7], this.transform.position, this.transform.rotation);
        clone.GetComponent<Boom_ef>().Dmg = Dmg_T;
        if (ef == 1) clone.GetComponent<Boom_ef>().R = eff1[1] * K;
        if (ef == 2) clone.GetComponent<Boom_ef>().R = eff2[1] * K;
        clone.GetComponent<Boom_ef>().M = m;
    }
    private void Water_ef(float m, int ef)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Terrain")
            {
                var clone = Instantiate(effs[4], hit.point, Quaternion.identity);
                clone.GetComponent<Luja_ef>().Dmg = Dmg_T;
                if (ef == 1)
                {
                    clone.GetComponent<Luja_ef>().time = eff1[2] * K;
                    clone.GetComponent<Luja_ef>().R = eff1[1] * K;
                }
                if (ef == 2)
                {
                    clone.GetComponent<Luja_ef>().time = eff2[2] * K;
                    clone.GetComponent<Luja_ef>().R = eff2[1] * K;
                }
                clone.GetComponent<Luja_ef>().M = m;
            }
        }
    }
    private void El_bolt(float m, int ef)
    {
        var clone = Instantiate(effs[3], this.transform.position, this.transform.rotation);
        if (ef == 1) clone.GetComponent<El_ef>().Kvo = (int)(eff1[1] * K);
        if (ef == 2) clone.GetComponent<El_ef>().Kvo = (int)(eff2[1] * K);
        clone.GetComponent<El_ef>().Dmg = Dmg_T;
        clone.GetComponent<El_ef>().M = m;
    }
    private void Gravitat_eff(float m, int ef)
    {
        var clone = Instantiate(effs[1], this.transform.position, this.transform.rotation);
        if (ef == 1)
        {
            clone.GetComponent<Gravitat_ef>().time = eff1[1] * K;
            clone.GetComponent<Gravitat_ef>().R = eff1[2] * K;
            clone.GetComponent<Gravitat_ef>().F = eff1[3] * K;
        }
        if (ef == 2)
        {
            clone.GetComponent<Gravitat_ef>().time = eff2[1] * K;
            clone.GetComponent<Gravitat_ef>().R = eff2[2] * K;
            clone.GetComponent<Gravitat_ef>().F = eff2[3] * K;
        }
        clone.GetComponent<Gravitat_ef>().Dmg = Dmg_T;
        clone.GetComponent<Gravitat_ef>().M = m;
    }
    private void Void_eff(float m, int ef)
    {
        var clone = Instantiate(effs[8], this.transform.position, this.transform.rotation);
        if (ef == 1)
        {
            clone.GetComponent<Void_ef>().time = eff1[1] * K;
            clone.GetComponent<Void_ef>().R = eff1[2] * K;
        }
        if (ef == 2)
        {
            clone.GetComponent<Void_ef>().time = eff2[1] * K;
            clone.GetComponent<Void_ef>().R = eff2[2] * K;
        }
        clone.GetComponent<Void_ef>().Dmg = Dmg_T;
        clone.GetComponent<Void_ef>().M = m;
    }
    private void Life_eff(float m, int ef)
    {
        var clone = Instantiate(effs[5], this.transform.position, this.transform.rotation);
        if (ef == 1)
        {
            clone.GetComponent<Life_ef>().time = eff1[1] * K;
            clone.GetComponent<Life_ef>().R = eff1[2] * K;
        }
        if (ef == 2)
        {
            clone.GetComponent<Life_ef>().time = eff2[1] * K;
            clone.GetComponent<Life_ef>().R = eff2[2] * K;
        }
        clone.GetComponent<Life_ef>().Dmg = Dmg_T;
        clone.GetComponent<Life_ef>().M = m;
    }
    private void Death_eff(float m, int ef)
    {
        var clone = Instantiate(effs[6], this.transform.position, this.transform.rotation);
        if (ef == 1)
        {
            clone.GetComponent<Death_ef>().time = eff1[1] * K;
            clone.GetComponent<Death_ef>().K = eff1[2] * K;
        }
        if (ef == 2)
        {
            clone.GetComponent<Death_ef>().time = eff2[1] * K;
            clone.GetComponent<Death_ef>().K = eff2[2] * K;
        }
        clone.GetComponent<Death_ef>().Dmg = Dmg_T;
        clone.GetComponent<Death_ef>().M = m;
    }
    private void Metal_eff(float m, int ef)
    {
        var clone = Instantiate(effs[2], this.transform.position, this.transform.rotation);
        if (ef == 1)
        {
            clone.GetComponent<Metal_ef>().time = eff1[1] * K;
            clone.GetComponent<Metal_ef>().K = eff1[2] * K;
        }
        if (ef == 2)
        {
            clone.GetComponent<Metal_ef>().time = eff2[1] * K;
            clone.GetComponent<Metal_ef>().K = eff2[2] * K;
        }
        clone.GetComponent<Metal_ef>().ef2 = (eff2.Length >= 1);
        clone.GetComponent<Metal_ef>().Dmg = Dmg_T;
        clone.GetComponent<Metal_ef>().M = m;
    }
}

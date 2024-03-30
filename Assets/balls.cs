using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class balls : MonoBehaviour
{

    public int Sphere1_id;
    public int Sphere2_id;
    public int Sphere3_id;

    public Transform St_point;
    public Transform tr_point;

    private int S_type;
    private float L_time;
    public float Spawn_time;
    public float s_time;
    private float Dmg;
    private float K_S;

    public Sphere[] spheres;
    public Snar[] snars;

    public float[] eff1;
    public float[] eff2;
    



    public void Relload()
    {
        if ((Sphere1_id != 0) && (Sphere2_id != 0) && (Sphere3_id != 0))
        {
            S_type = spheres[Sphere1_id].type_s;
            float t = 1f;
            //==================================================================//

            float k1 = Mathf.Abs(Mathf.Cos(Mathf.PI * (Sphere1_id - Sphere2_id) / 8f));
            float k2 = Mathf.Abs(Mathf.Cos(Mathf.PI * (Sphere2_id - Sphere3_id) / 8f));
            if (k1 < 0.2f) k1 = 0.2f;
            if (k2 < 0.2f) k2 = 0.2f;
            if ((Sphere1_id == Sphere2_id) && (Sphere2_id == Sphere3_id)) t = 0.8f;
            K_S = t * (k1 + k2) / 2;

            //==================================================================//

            float k = spheres[Sphere1_id].ef_time;
            if (Sphere1_id == 6) k = Time.deltaTime * 15;

            Dmg = (spheres[Sphere1_id].dmg + spheres[Sphere2_id].dmg + spheres[Sphere3_id].dmg) / 3 * K_S * snars[S_type].Power;
            if (Dmg == 0) L_time = K_S / ((Mathf.Abs(Dmg) + 1) * k);
            else L_time = 1000 * K_S / (Mathf.Abs(Dmg) * k * ((spheres[Sphere2_id].ef_time * 1.5f + 1) / 2.5f) * ((spheres[Sphere3_id].ef_time * 1.5f + 1) / 2.5f));


            print("/////" + Dmg + '/' + L_time);
            SpawnS(S_type);
        }
    }

    private void SpawnS(int type)
    {
        if (type == 5)
        {
            var clone = Instantiate(snars[S_type].Sn, St_point.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce((St_point.position.x - tr_point.position.x) * L_time * -10, (St_point.position.y - tr_point.position.y) * L_time * -10, (St_point.position.z - tr_point.position.z) * L_time * -10, ForceMode.Impulse);
            clone.GetComponent<Botik>().life_T = snars[S_type].life_time;
            clone.GetComponent<Botik>().Dmg_T = Dmg;

            float[] array = { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            array[Sphere1_id] += 100;
            array[Sphere2_id] += 75;
            array[Sphere3_id] += 50;
            int maxIndex = array.ToList().IndexOf(array.Max());
            eff1 = spheres[maxIndex].eff;
            array[maxIndex] = 0;
            maxIndex = array.ToList().IndexOf(array.Max());
            eff2 = spheres[maxIndex].eff;

            clone.GetComponent<Botik>().eff1 = eff1;
            clone.GetComponent<Botik>().eff2 = eff2;
            clone.GetComponent<Botik>().K = K_S;
            clone.GetComponent<Botik>().S_type = S_type;

            clone.GetComponent<Botik>().StartSim();
        }
        else
        {
            var clone = Instantiate(snars[S_type].Sn, St_point.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce((St_point.position.x - tr_point.position.x) * L_time * -10, (St_point.position.y - tr_point.position.y) * L_time * -10, (St_point.position.z - tr_point.position.z) * L_time * -10, ForceMode.Impulse);
            clone.GetComponent<SnarScript>().life_T = snars[S_type].life_time;
            clone.GetComponent<SnarScript>().Dmg_T = Dmg;

            float[] array = { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            array[Sphere1_id] += 100;
            array[Sphere2_id] += 75;
            array[Sphere3_id] += 50;
            int maxIndex = array.ToList().IndexOf(array.Max());
            eff1 = spheres[maxIndex].eff;
            array[maxIndex] = 0;
            maxIndex = array.ToList().IndexOf(array.Max());
            eff2 = spheres[maxIndex].eff;

            clone.GetComponent<SnarScript>().eff1 = eff1;
            clone.GetComponent<SnarScript>().eff2 = eff2;
            clone.GetComponent<SnarScript>().K = K_S;
            clone.GetComponent<SnarScript>().S_type = S_type;


            //Запуск снаряда
            clone.GetComponent<SnarScript>().StartSim();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F)|OVRInput.Get(OVRInput.Button.One))
        {
            s_time += Time.deltaTime;
            this.GetComponent<MeshRenderer>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.F) | OVRInput.GetUp(OVRInput.Button.One))
        {
            if (s_time >= Spawn_time) 
            {
                Relload();
            }
            s_time = 0;
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}

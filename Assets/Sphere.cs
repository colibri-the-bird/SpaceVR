using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Sphere", order = 1)]
public class Sphere : ScriptableObject
{
    public int type_s;
    public float dmg;
    public float ef_time;
    public int ef_id;
    public float[] eff;
}
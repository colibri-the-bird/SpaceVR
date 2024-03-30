using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Snar", order = 1)]
public class Snar : ScriptableObject
{
    public float life_time;
    public float Power;
    public GameObject Sn;
}
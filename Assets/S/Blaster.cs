using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public Transform St_point;
    public Transform tr_point;
    public float Spawn_time;
    private float s_time;
    public GameObject orb;
    public float Dmg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Spawnn()
    {
        var clone = Instantiate(orb, St_point.position, Quaternion.identity);
        clone.transform.LookAt(tr_point.transform.position, Vector3.up);
        clone.GetComponent<Rigidbody>().AddForce((St_point.position.x - tr_point.position.x)  * -100, (St_point.position.y - tr_point.position.y) *  -100, (St_point.position.z - tr_point.position.z)  * -100, ForceMode.Impulse);
        clone.GetComponent<Bolt>().Dmg_T = Dmg;
    }

    // Update is called once per frame
    void Update()
    {
        s_time += Time.deltaTime;
        if (Input.GetKey(KeyCode.G) | OVRInput.Get(OVRInput.Button.Three))
        {
            if (s_time >= Spawn_time)
            {
                Spawnn();
                s_time = 0;
            }
        }
    }
}

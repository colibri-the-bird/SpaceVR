using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    public Transform center;
    public GameObject[] enemies;
    public int Loc_ID;
    public float spawn_speed;
    public float R_nospawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StCoroutine());
    }

    private IEnumerator StCoroutine()
    {
        while (true)
        {
            System.Random rand = new System.Random();
            RaycastHit[] hits;
            hits = Physics.RaycastAll(new Vector3(((float)rand.NextDouble() - 0.5f) * 100 + this.transform.position.x, this.transform.position.y + 500, ((float)rand.NextDouble() - 0.5f) * 100 + this.transform.position.z), new Vector3(0,-1,0), 1000.0F);
            var a = false;
            var b = true;
            Vector3 coord = new Vector3 (0,0,0);
            for(int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.tag != "Underground")
                {
                    b = false;
                    break;
                }
                if ((hits[i].collider.tag == "Underground")&&(Vector3.Distance(hits[i].point,center.position) > R_nospawn))
                {
                    a = true;
                    coord = hits[i].point;
                }
                
            }
            if (a && b)
            {
                var clone = Instantiate(enemies[Loc_ID], coord, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawn_speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

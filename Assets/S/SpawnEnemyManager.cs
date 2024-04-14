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
            GameObject firstObj = null;
            Vector3 pos = new Vector3(0,0,0);
            Vector3 position = new Vector3(((float)rand.NextDouble() - 0.5f) * 100 + this.transform.position.x, this.transform.position.y + 150, ((float)rand.NextDouble() - 0.5f) * 100 + this.transform.position.z);
            RaycastHit hit;
            Ray ray = new Ray(position, new Vector3(0, -1, 0));
            if (Physics.Raycast(ray, out hit))
            {
                if ((firstObj == null)&&(hit.collider.gameObject.name != "Trigger"))
                {
                    firstObj = hit.collider.gameObject;
                    pos = hit.point;
                }

            }
            if (firstObj != null)
            {
                print(firstObj.name);
                if (firstObj.tag == "Underground")
                {
                    Instantiate(enemies[Loc_ID], pos, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(spawn_speed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

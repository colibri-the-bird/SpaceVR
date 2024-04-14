using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls_box : MonoBehaviour
{
    public int Type;
    private int id;



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "G") 
        {
            id = 1;
            collision.gameObject.name = "EmptySphere";
            collision.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }
        if (collision.gameObject.name == "M")
        {
            id = 2;
            collision.gameObject.name = "EmptySphere";
            collision.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }
        if (collision.gameObject.name == "E")
        {
            id = 3;
            collision.gameObject.name = "EmptySphere";
            collision.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }
        if (collision.gameObject.name == "W")
        {
            id = 4;
            collision.gameObject.name = "EmptySphere";
            collision.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }
        if (collision.gameObject.name == "L")
        {
            id = 5;
            collision.gameObject.name = "EmptySphere";
            collision.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }
        if (collision.gameObject.name == "D")
        {
            id = 6;
            collision.gameObject.name = "EmptySphere";
            collision.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }
        if (collision.gameObject.name == "F")
        {
            id = 7;
            collision.gameObject.name = "EmptySphere";
            collision.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }
        if (collision.gameObject.name == "V")
        {
            id = 8;
            collision.gameObject.name = "EmptySphere";
            collision.gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }
        if (Type == 1)
        {
            this.transform.parent.parent.GetComponent<balls>().Sphere1_id = id;
        }
        if (Type == 2)
        {
            this.transform.parent.parent.GetComponent<balls>().Sphere2_id = id;
        }
        if (Type == 3)
        {
            this.transform.parent.parent.GetComponent<balls>().Sphere3_id = id;
        }
    }
}

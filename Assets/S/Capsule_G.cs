using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using TMPro;

public class Capsule_G : MonoBehaviour
{
    public bool Pass = false;
    public bool Capsule_Pass = false;
    public bool Time_Pass = false;
    public bool CanStart = false;
    public GameObject Mayak;
    private bool d = false;
    private bool a = false;
    private bool b = false;
    private GameObject clone;
    public GameObject Player;
    private float time;

    private int[] refer;
    private int[] tryy;
    private string[] txt;

    public GameObject[] obj;
    public TMP_Text m_TextComponent;


    public GameObject civil;
    // Start is called before the first frame update
    void Start()
    {
        MiniGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanStart && !d)
        {
            clone = Instantiate(Mayak, this.transform.position, this.transform.rotation);
            d = true;
        }
        if (Capsule_Pass && !a)
        {
            var clon = Instantiate(civil, this.transform.position, this.transform.rotation);
            clon.GetComponent<Civil>().Parent = this.gameObject;
            CanStart = false;
            Destroy(clone); clone = null;
            a = true;
        }
        if (Time_Pass && !b && (Player.GetComponent<SpawnEnemyManager>().Loc_ID == 0))
        {
            time += Time.deltaTime;
        }
        if ((time >= 60) && !b)
        {
            Pass = true;
            b = true;
        }
        if ((obj.Length > 0) && CanStart && !Capsule_Pass)
        {
            if (Input.GetKeyDown(KeyCode.U) | OVRInput.GetDown(OVRInput.Button.One)) tryy = tryy.Append(0).ToArray();
            if (Input.GetKeyDown(KeyCode.I) | OVRInput.GetDown(OVRInput.Button.Two)) tryy = tryy.Append(1).ToArray();
            if (Input.GetKeyDown(KeyCode.O) | OVRInput.GetDown(OVRInput.Button.Three)) tryy = tryy.Append(2).ToArray();
            if (Input.GetKeyDown(KeyCode.P) | OVRInput.GetDown(OVRInput.Button.Four)) tryy = tryy.Append(3).ToArray();
            if (tryy.Length > 0)
            {
                for (int i = 0; i < tryy.Length; i++)
                {
                    if (tryy[i] != refer[i]) MiniGame();
                    else if(tryy.Length == refer.Length)
                    {
                        print("win");
                        Capsule_Pass = true;
                    }
                }
            }
        }
    }

    private void MiniGame()
    {
        System.Random rand = new System.Random();
        refer = new int[] { rand.Next(0,4), rand.Next(0, 4), rand.Next(0, 4), rand.Next(0, 4), rand.Next(0, 4) };
        tryy = new int[0];
        txt = new string[0];
        foreach (int i in refer)
        {
            if (i == 0) txt = txt.Append("A").ToArray();
            if (i == 1) txt = txt.Append("B").ToArray();
            if (i == 2) txt = txt.Append("X").ToArray();
            if (i == 3) txt = txt.Append("Y").ToArray();
        }
        m_TextComponent.text = txt[0] + "_" + txt[1] + "_" + txt[2] + "_" + txt[3] + "_" + txt[4];
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            obj = obj.Append(collision.gameObject).ToArray();
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            obj = obj.Where(val => val != collision.gameObject).ToArray();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Botik : MonoBehaviour
{
    public float HP = 1000;
    public float DefK = 1;
    private bool d;

    Animator animator;
    //================================================================
    public Transform finih;
    RaycastHit Hit;
    bool stena, stenaTime;
    Vector3 PovorotDlaObxoda;
    Transform TargetPregrada;
    Vector3 NapravlenieLy4a;
    public Transform[] ForvardRay;
    public Transform[] LeftRay;
    public Transform[] RightRay;

    Transform[] pointRay;
    int distansRay = 3;
    public float speedCube = 3;
    public float R;
    float timeFlag;


    //================================================================


    public GameObject[] obj;
    public GameObject[] floor;
    private bool atc;

    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public float life_T;
    public float Dmg_T;
    public float K;
    public float[] eff1;
    public float[] eff2;
    public int S_type;

    private bool started;



    public GameObject[] effs;

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void StartSim()
    {
        StartCoroutine(SttCoroutine());
    }
    private IEnumerator SttCoroutine()
    {
        yield return new WaitForSeconds(life_T);
        if (!started) StEffect();

    }
    public void StEffect()
    {
        started = true;
        if (eff1[0] == 7) Boom_eff(0.5f,1);
        if (eff1[0] == 4) Water_ef(0.5f, 1);
        if (eff1[0] == 3) El_bolt(0.5f, 1);
        if (eff1[0] == 1) Gravitat_eff(0.5f, 1);
        if (eff1[0] == 8) Void_eff(0.5f, 1);
        if (eff1[0] == 5) Life_eff(0.5f, 1);
        if (eff1[0] == 6) Death_eff(0.5f, 1);
        if (eff1[0] == 2) Metal_eff(0.5f, 1);

        if (eff2[0] == 7) Boom_eff(0.25f, 2);
        if (eff2[0] == 4) Water_ef(0.25f, 2);
        if (eff2[0] == 3) El_bolt(0.25f, 2);
        if (eff2[0] == 1) Gravitat_eff(0.25f, 2);
        if (eff2[0] == 8) Void_eff(0.25f, 2);
        if (eff2[0] == 5) Life_eff(0.25f, 2);
        if (eff2[0] == 6) Death_eff(0.25f, 2);
        if (eff2[0] == 2) Metal_eff(0.25f, 2);
        Destroy(this.gameObject);
    }
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


    //==========================================================================================================


    // Update is called once per frame
    void Update()
    {
        if (finih == null)
        {
            animator.ResetTrigger("Move");
        }
        if (obj.Length == 0)
        {
            animator.ResetTrigger("Attack");
        }
        if (HP <= 0)
        {
            finih = null;
            animator.SetTrigger("Dead");
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) d = true;
        }
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Death") && d)
        {
            Destroy(this.gameObject);
        }
        if ((finih != null) && (floor.Length != 0))
        {
            animator.SetTrigger("Move");
            //непрерывное движение куба пока то не достигнет цели
            if (Vector3.Distance(finih.position, transform.position) > R)
            {
                transform.position += transform.forward * speedCube * Time.deltaTime;
            }
            if (!stena)
            {
                //дебаг линия от куба к цели
                UnityEngine.Debug.DrawLine(finih.position, transform.position, Color.red);
                //поворот в направлении основной цели
                transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(finih.position - transform.position), Time.deltaTime * 2f);
                NapravlenieLy4a = transform.forward;
                pointRay = ForvardRay;
                distansRay = 2;
            }
            else
            {
                if (TargetPregrada != null)
                {
                    // меняем направление луча в случае запуска опции обхода преграды
                    NapravlenieLy4a = OptionRay(TargetPregrada, transform);
                    //меняем точки пускания лучей на самые ближние к преграде
                    pointRay = NapravlenieLy4a == -transform.right ? LeftRay : RightRay;
                    distansRay = 4;
                }
            }
            byte rayIntPoint = 0;
            for (int i = 0; i < pointRay.Length; i++)
            {
                //лучи в дебаге
                UnityEngine.Debug.DrawRay(pointRay[i].position, NapravlenieLy4a, Color.green);
                //пускаем лучи из выбранных точек
                if (Physics.Raycast(pointRay[i].position, NapravlenieLy4a, out Hit, distansRay))
                {
                    if ((NapravlenieLy4a == transform.forward) && (Hit.collider.gameObject.GetComponent<Player>() == null) && (Hit.collider.gameObject.GetComponent<Botik>() == null) && (Hit.collider.gameObject.GetComponent<Enemy>() == null))
                    {
                        stena = true;
                        TargetPregrada = Hit.transform;
                        //поворачиваем наш кубик к ближайшему краю преграды
                        transform.localRotation = Quaternion.Euler(OptionDirection(TargetPregrada, transform));
                    }
                    else stena = true;
                    break;
                }
                else if ((NapravlenieLy4a != transform.forward && !stenaTime) && (TargetPregrada != null))
                {
                    rayIntPoint++;
                    if (rayIntPoint >= pointRay.Length)
                    {
                        //разворачиваем кубик в исходное положение и даем ему 1 секунду чтобы пройти мимо преграды и не цеплятся за края,
                        //далее снова включаем курс на конечную цель
                        timeFlag = Time.time + 2;
                        stenaTime = true;
                        Vector3 povorot = TargetPregrada.rotation.eulerAngles;
                        transform.localRotation = Quaternion.Euler(povorot);
                    }
                }
            }
            if (timeFlag + 1 < Time.time && stenaTime)
            {
                stenaTime = false;
                stena = false;
            }
        }
    }
    Vector3 OptionDirection(Transform block, Transform myTransform)
    {
        Vector3 vec = block.transform.rotation.eulerAngles;
        vec.y = block.transform.position.x < myTransform.position.x ? vec.y += 90 : vec.y -= 90;
        return vec;
    }
    //выбор направлния лучей
    Vector3 OptionRay(Transform block, Transform myTransform)
    {
        Vector3 vec;
        return vec = TargetPregrada.position.x < myTransform.position.x ? -myTransform.right : myTransform.right;
    }
    private IEnumerator StCoroutine()
    {

        while (atc)
        {
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length / 2);
            if (obj != null)
            {
                foreach (var e in obj)
                {
                    if (e != null) e.GetComponent<Enemy>().HP -= e.GetComponent<Enemy>().DefK * Dmg_T/life_T*5;
                }
            }
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length / 2);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        floor = floor.Append(collision.gameObject).ToArray();
    }
    private void OnCollisionExit(Collision collision)
    {
        floor = floor.Where(val => val != collision.gameObject).ToArray();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            obj = obj.Append(collision.gameObject).ToArray();
            atc = true;
            StartCoroutine(StCoroutine());
        }
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            obj = obj.Where(val => val != collision.gameObject).ToArray();
            atc = false;
            StopCoroutine(StCoroutine());
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class AAA : MonoBehaviour
{
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

    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        UnityEngine.Debug.Log(Vector3.Distance(finih.position, transform.position));
        //����������� �������� ���� ���� �� �� ��������� ����
        if (Vector3.Distance(finih.position, transform.position) > R)
        {
            transform.position += transform.forward * speedCube * Time.deltaTime;
        }
        if (!stena)
        {
            //����� ����� �� ���� � ����
            UnityEngine.Debug.DrawLine(finih.position, transform.position, Color.red);
            //������� � ����������� �������� ����
            transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(finih.position - transform.position), Time.deltaTime * 2f);
            NapravlenieLy4a = transform.forward;
            pointRay = ForvardRay;
            distansRay = 2;
        }
        else
        {
            // ������ ����������� ���� � ������ ������� ����� ������ ��������
            NapravlenieLy4a = OptionRay(TargetPregrada, transform);
            //������ ����� �������� ����� �� ����� ������� � ��������
            pointRay = NapravlenieLy4a == -transform.right ? LeftRay : RightRay;
            distansRay = 4;
        }
        byte rayIntPoint = 0;
        for (int i = 0; i < pointRay.Length; i++)
        {
            //���� � ������
            UnityEngine.Debug.DrawRay(pointRay[i].position, NapravlenieLy4a, Color.green);
            //������� ���� �� ��������� �����
            if (Physics.Raycast(pointRay[i].position, NapravlenieLy4a, out Hit, distansRay))
            {
                if (NapravlenieLy4a == transform.forward)
                {
                    stena = true;
                    TargetPregrada = Hit.transform;
                    //������������ ��� ����� � ���������� ���� ��������
                    transform.localRotation = Quaternion.Euler(OptionDirection(TargetPregrada, transform));
                }
                else stena = true;
                break;
            }
            else if (NapravlenieLy4a != transform.forward && !stenaTime)
            {
                rayIntPoint++;
                if (rayIntPoint >= pointRay.Length)
                {
                    //������������� ����� � �������� ��������� � ���� ��� 1 ������� ����� ������ ���� �������� � �� �������� �� ����,
                    //����� ����� �������� ���� �� �������� ����
                    timeFlag = Time.time;
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
    //����� ����������� ������ �����������.
    Vector3 OptionDirection(Transform block, Transform myTransform)
    {
        Vector3 vec = block.transform.rotation.eulerAngles;
        vec.y = block.transform.position.x < myTransform.position.x ? vec.y += 90 : vec.y -= 90;
        return vec;
    }
    //����� ���������� �����
    Vector3 OptionRay(Transform block, Transform myTransform)
    {
        Vector3 vec;
        return vec = TargetPregrada.position.x < myTransform.position.x ? -myTransform.right : myTransform.right;
    }
}
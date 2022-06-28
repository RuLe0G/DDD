using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectScript : MonoBehaviour
{
    CObject objRef = new CObject(); //��������� ������� (���, ���, �������, �������, �������)
    public string prefType;         //��� ������� �� �������� ��� ������ ������
    
    //string tagCreate = "Create_Unity"; //��� ��������
    //string tagComplete = "Complete_Unity"; //��� ����������

    public Collider OriginCollider; //��������� ������� ����� ����������
    //public Collider ChekCollider; //��������� ������� ��� ���d���� �����������

    CharacterObject ChekedObject;


    //private Outline outline; //�������

    // Start is called before the first frame update
    void Start()    //���������� ���������� ������� ��� ������ ������ �������
    {
        ChekedObject = GetComponent<CharacterObject>();

        objRef.name = this.name;

        objRef.type = prefType;

        objRef.x = transform.position.x;
        objRef.y = transform.position.x;
        objRef.z = transform.position.x;

        objRef.rx = transform.rotation.x;
        objRef.ry = transform.rotation.y;
        objRef.rz = transform.rotation.z;
        objRef.w = transform.rotation.w;


        objRef.sx = transform.localScale.x;
        objRef.sy = transform.localScale.y;
        objRef.sz = transform.localScale.z;

        objRef.Dialog = ChekedObject.Dialog;
        objRef.Light = ChekedObject.Light_source;
        objRef.Take = ChekedObject.Take;
        objRef.Interaction = ChekedObject.Interaction;
        objRef.Storage = ChekedObject.Storage;

        Global.addObject(objRef);
        Global.oScripts.Add(this);
    }

    //void Update()
    //{
    //    //���� ������ �� ������������ � ������ � ������ �������������
    //    if (gameObject.tag == tagCreate && Cheked_Construction.OnTriggerUnit == false)
    //    {
    //        gameObject.GetComponentInChildren<MeshRenderer>().material = Ghost;
    //        OriginCollider.enabled = false;
    //        ChekCollider.enabled = true;
    //    }

    //    //���� ������ ������������ � ������ � ������ �������������
    //    if (gameObject.tag == tagCreate && Cheked_Construction.OnTriggerUnit == true)
    //    {
    //        gameObject.GetComponentInChildren<MeshRenderer>().material = GhostNo;
    //        OriginCollider.enabled = false;
    //        ChekCollider.enabled = true;
    //    }

    //    if (gameObject.tag == tagComplete)
    //    {
    //        gameObject.GetComponentInChildren<MeshRenderer>().material = Origin;
    //        OriginCollider.enabled = true;
    //        ChekCollider.enabled = false;
    //    }

    //}


    //void OnTriggerEnter()
    //{
    //    Cheked_Construction.OnTriggerUnit = true; //���� ����������� �����������
    //}

    //void OnTriggerExit()
    //{
    //    Cheked_Construction.OnTriggerUnit = false; //��� ����������� �����������
    //}


    //public void OnMouseExit() //����� ������ ������� �� �������
    //{
    //    outline.OutlineWidth = 0;
    //}

    public void updateInfo()    //���������� ���������� �������
    {
        objRef.x = transform.position.x;
        objRef.y = transform.position.y;
        objRef.z = transform.position.z;

        objRef.rx = transform.rotation.x;
        objRef.ry = transform.rotation.y;
        objRef.rz = transform.rotation.z;
        objRef.w = transform.rotation.w;

        objRef.sx = transform.localScale.x;
        objRef.sy = transform.localScale.y;
        objRef.sz = transform.localScale.z;

        objRef.Dialog = ChekedObject.Dialog;
        objRef.Light = ChekedObject.Light_source;
        objRef.Take = ChekedObject.Take;
        objRef.Interaction = ChekedObject.Interaction;
        objRef.Storage = ChekedObject.Storage;
    }

    public void del()   //�������� �������
    {
        Global.delObject(objRef);
        Global.oScripts.Remove(this);

        Destroy(this.transform.gameObject);
    }
}

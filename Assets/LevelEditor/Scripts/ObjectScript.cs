using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectScript : MonoBehaviour
{
    CObject objRef = new CObject(); //параметры объекта (имя, тип, позиция, поворот, масштаб)
    public string prefType;         //имя префаба по которому был создан объект
    
    //string tagCreate = "Create_Unity"; //тег создания
    //string tagComplete = "Complete_Unity"; //тег завершения

    public Collider OriginCollider; //коллайдер объекта после завершения
    //public Collider ChekCollider; //коллайдер объекта для проdерки пересечений

    CharacterObject ChekedObject;


    //private Outline outline; //обводка

    // Start is called before the first frame update
    void Start()    //заполнение параметров объекта при старте работы объекта
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
    //    //Если объект не пересекается с другим в режиме строительства
    //    if (gameObject.tag == tagCreate && Cheked_Construction.OnTriggerUnit == false)
    //    {
    //        gameObject.GetComponentInChildren<MeshRenderer>().material = Ghost;
    //        OriginCollider.enabled = false;
    //        ChekCollider.enabled = true;
    //    }

    //    //Если объект пересекается с другим в режиме строительства
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
    //    Cheked_Construction.OnTriggerUnit = true; //есть пересечения коллайдеров
    //}

    //void OnTriggerExit()
    //{
    //    Cheked_Construction.OnTriggerUnit = false; //нет пересечения коллайдеров
    //}


    //public void OnMouseExit() //когда курсор выходит из объекта
    //{
    //    outline.OutlineWidth = 0;
    //}

    public void updateInfo()    //обновление параметров объекта
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

    public void del()   //удаление объекта
    {
        Global.delObject(objRef);
        Global.oScripts.Remove(this);

        Destroy(this.transform.gameObject);
    }
}

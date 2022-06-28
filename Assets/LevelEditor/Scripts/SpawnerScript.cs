using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] prefabs;    //список префабов

    [HideInInspector]
    public Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>(); //словарь префабов, ключём является имя префаба



    void Start()
    {
        objects.Clear();
        foreach (GameObject ob in prefabs)  //преобразование списка в словарь
        {
            objects.Add(ob.name, ob);
        }
    }

    public void SpawnObject(string name)    //добавление объекта по указанному имени префаба
    {
        GameObject ob = Instantiate(objects[name], transform);
        ObjectScript os = ob.GetComponent<ObjectScript>();
        os.prefType = name; //добавление имени префаба в объект
    }
}



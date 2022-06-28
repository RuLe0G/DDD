using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] prefabs;    //������ ��������

    [HideInInspector]
    public Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>(); //������� ��������, ������ �������� ��� �������



    void Start()
    {
        objects.Clear();
        foreach (GameObject ob in prefabs)  //�������������� ������ � �������
        {
            objects.Add(ob.name, ob);
        }
    }

    public void SpawnObject(string name)    //���������� ������� �� ���������� ����� �������
    {
        GameObject ob = Instantiate(objects[name], transform);
        ObjectScript os = ob.GetComponent<ObjectScript>();
        os.prefType = name; //���������� ����� ������� � ������
    }
}



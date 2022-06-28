using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

public class SaveLoadScript : MonoBehaviour
{
    public SpawnerScript spawner;   //������ �� ������, ��������� �������, ����� ��� ��������

    string SaveFilePath;


    private void Start()
    {
        Load();
    }

    public void Save()
    {
    //    Global.updateObjectsInfo(); //���������� ���������� �������� ����� �����������

    //    SaveFilePath = EditorUtility.SaveFilePanel("save", "", "", "txt");

    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream fs = new FileStream(SaveFilePath, FileMode.Create);

    //    bf.Serialize(fs, Global.objects);

    //    fs.Close();

    //    Debug.Log("Complete Save");
    //    Debug.Log(SaveFilePath);



        //foreach (CObject ob in Global.objects)
        //{
        //    Debug.Log(ob.name);
        //    Debug.Log(ob.type);
        //    Debug.Log("------------------------------------");
        //}
    }



    public void Load()
    {
        string LoadFilePath = Gloabal.LoadFilePath;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(LoadFilePath, FileMode.Open);

        List<CObject> obCopy = (List<CObject>)bf.Deserialize(fs);
        fs.Close();

        //List<CObject> obCopy = new List<CObject>(); //��������� ������ ����������, ����������� �� �����

        foreach (CObject ob in obCopy)
        {
            Global.objects.Add(ob);
        }
        //-=========================================================

        foreach (Transform child in spawner.transform)
        {
            Destroy(child.gameObject);
        }

        Global.objects.Clear();     //������� �������� ������ ����������
        Global.oScripts.Clear();    //������� �������� ������ ��������

        foreach (CObject ob in obCopy)  //���������� �������� � ������������ �����������
        {
            GameObject obj = Instantiate(spawner.objects[ob.type], new Vector3(ob.x, ob.y, ob.z), new Quaternion(ob.rx, ob.ry, ob.rz, ob.w));
            ObjectScript os = obj.GetComponent<ObjectScript>();
            os.prefType = ob.type;
            obj.name = ob.name;
            obj.transform.parent = spawner.transform;
        }

    }
}
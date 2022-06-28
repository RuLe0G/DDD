using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CObject    //������ ���������� ��� ����������
{
    public string name; //��� �������
    public string type; //��� ������� �� �������� ������ ��� ������

    public float x, y, z;           //�������
    public float rx, ry, rz, w;     //�������
    public float sx, sy, sz;        //�������

    public bool Dialog;
    public bool Light;
    public bool Take;
    public bool Interaction;
    public bool Storage;
}

public static class Global
{
    public static List<CObject> objects = new List<CObject>();              //������ ���������� ��������
    public static List<ObjectScript> oScripts = new List<ObjectScript>();   //������ ������ �� ���� �������

    static public void addObject(CObject ob)    //���������� ������� � ������
    {
        objects.Add(ob);
    }

    static public void delObject(CObject ob)    //�������� ������� �� ������
    {
        objects.Remove(ob);
    }

    public static void updateObjectsInfo()  //���������� ���������� ��������
    {
        foreach (ObjectScript os in oScripts)
        {
            os.updateInfo();
        }
    }

}

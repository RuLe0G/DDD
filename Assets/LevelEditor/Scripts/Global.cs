using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CObject    //формат параметров для сохранения
{
    public string name; //имя объекта
    public string type; //имя префаба из которого объект был сделан

    public float x, y, z;           //позиция
    public float rx, ry, rz, w;     //поворот
    public float sx, sy, sz;        //масштаб

    public bool Dialog;
    public bool Light;
    public bool Take;
    public bool Interaction;
    public bool Storage;
}

public static class Global
{
    public static List<CObject> objects = new List<CObject>();              //список параметров объектов
    public static List<ObjectScript> oScripts = new List<ObjectScript>();   //список ссылок на сами объекты

    static public void addObject(CObject ob)    //добавление объекта в список
    {
        objects.Add(ob);
    }

    static public void delObject(CObject ob)    //удаление объекта из списка
    {
        objects.Remove(ob);
    }

    public static void updateObjectsInfo()  //обновление параметров объектов
    {
        foreach (ObjectScript os in oScripts)
        {
            os.updateInfo();
        }
    }

}

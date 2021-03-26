using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
//valor de las estadisticas en forma de clase para que al cambiar se actualizen solas;
public class RefStat
{
    public float value;
    //referencia sobre que stat trabaja para saber cuando recalcular el valor total
    public Stat reference;
    public RefStat(float v) 
    {
        value = v;
    }
    public void Add(float v)
    {
        value += v;
        reference.changed = true;
    }
    public void Remove(float v)
    {
        value -= v;
        reference.changed = true;
    }
}
[System.Serializable]

public class Stat
{
    //ver en inspector, editables mediante funciones solamente
    [SerializeField]
    float value;
    [SerializeField]
    float basevalue;
    [SerializeField]
    float additive;
    [SerializeField]
    float multiplicative;
    //bool para actualizar
    [System.NonSerialized]
    public bool changed = false;
    //listas de estadisticas additivas y multiplicativas
    List<RefStat> extraValues = new List<RefStat>();
    List<RefStat> extraMaxValues = new List<RefStat>();
    //constructor
    public Stat(float bv)
    {
        basevalue = bv;
        CalcValue();
    }
    public float GetExtraValues()
    {
        float total = 0;
        foreach (RefStat stat in extraValues)
        {
            total += stat.value;
        }
        additive = total;
        return total;
    }
    public float GetExtraMaxValues()
    {
        float total = 0;
        foreach (RefStat stat in extraMaxValues)
        {
            total += stat.value;
        }
        multiplicative = total;
        return total;
    }
    public void CalcValue() 
    {
        value = (basevalue + GetExtraValues()) * (1 + (GetExtraMaxValues()/100));
        changed = false;
    }
    public void AddExtraValue(RefStat v) 
    {
        v.reference = this;
        extraValues.Add(v);
        changed = true;
    }
    public void AddBaseValue(float v)
    {
        basevalue += v;
        changed = true;
    }
    public void AddExtraMaxValue(RefStat v)
    {
        v.reference = this;
        extraMaxValues.Add(v);
        changed = true;
    }
    public void RemoveExtraValue(RefStat v)
    {
        v.reference = null;
        extraValues.Remove(v);
        changed = true;
    }
    public void RemoveBaseValue(float v)
    {
        basevalue -= v;
        changed = true;
    }
    public void RemoveExtraMaxValue(RefStat v)
    {
        v.reference = null;
        extraMaxValues.Remove(v);
        changed = true;
    }
    public float GetValue()
    {
        if (changed)
            CalcValue();

        return value;
    }
}
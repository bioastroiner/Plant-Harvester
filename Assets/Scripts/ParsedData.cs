using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParsedData<data>
{
    private data value;

    public bool isNull { get { return value == null; } }

    public ParsedData(data data)
    {
        value = data;
    }

    public data Value()
    {
        if(value == null)
        {
            Debug.Log("tracking data is gone : null");
            return default(data);
            //throw new System.NullReferenceException();
        }
        return value;
    }
}

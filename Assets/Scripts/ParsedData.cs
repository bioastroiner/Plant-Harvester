using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParsedData<data>
{
    private data value;

    public ParsedData(data data)
    {
        value = data;
    }

    public data Value()
    {
        if(value == null)
        {
            Debug.Log("tracking data is gone : null");
            throw new System.NullReferenceException();
        }
        return value;
    }
}

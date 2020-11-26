using UnityEngine;
using System.Collections;

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
            Debug.Log("source is gone : null");
            throw new System.NullReferenceException();
        }
        return value;
    }
}

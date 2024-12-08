using System.Collections;
using UnityEngine;

public class LineQueue : MonoBehaviour
{
    [SerializeField] Transform edge;
    [SerializeField] float gapSize;
    [SerializeField] float endLineOffset;

    [SerializeField] int lineCount;

    public static LineQueue singleton;

    void Start()
    {
        if(singleton == null) singleton = this;
        endLineOffset = 0;
    }

    //returns the transform adjusted to add the new customer
    public Vector3 JoinLine(){
        lineCount++;
        //add to end of line
        endLineOffset -= gapSize; //move end of line back
        
        return new Vector3(edge.position.x - endLineOffset, edge.position.y, 0);
    }

    public void RemoveCustomer(){
        lineCount--;
        endLineOffset += gapSize; //move
    }

    public Vector3 GetEndOfLine(){
        return new Vector3(edge.position.x - endLineOffset, edge.position.y, 0);
    }
}
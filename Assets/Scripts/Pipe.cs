using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    public Transform Destination;      
    public string TagList = "|Player|Boss|Friendly|"; 

    
    void Start()
    {
        
    }

 
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (TagList.Contains(string.Format("|{0}|", other.tag)))
        {
            
            other.transform.position = Destination.transform.position;
            
        }
    }
}

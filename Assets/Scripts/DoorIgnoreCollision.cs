using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIgnoreCollision : MonoBehaviour
{
    public GameObject wall;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), wall.gameObject.GetComponent<Collider>());
    }
}

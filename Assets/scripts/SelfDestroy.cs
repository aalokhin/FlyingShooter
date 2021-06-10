using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    /* object is going to be destroyed in timeTillDestroy time units. Needed to be able to isolate object destruction */
    [SerializeField] float timeTillDestroy = 0.1f;

    void Start()
    {
        Destroy(gameObject, timeTillDestroy); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

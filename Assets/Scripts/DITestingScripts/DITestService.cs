using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DITestService : IDITestService
{
    public void Greet()
    {
        Debug.Log("Hello DI Testing");
    }

    
}

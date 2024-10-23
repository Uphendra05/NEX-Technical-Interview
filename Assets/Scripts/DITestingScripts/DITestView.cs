using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DITestView : MonoBehaviour
{

    private IDITestService m_TestService;


    [Inject]
    public void Construct(IDITestService testService)
    {
        m_TestService = testService;
    }


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        m_TestService.Greet();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    private static int m_AudioCount;

    private void Awake()
    {
        m_AudioCount++;
        if (m_AudioCount > 1)
        {
            Destroy(gameObject);
            m_AudioCount = 1;
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

}

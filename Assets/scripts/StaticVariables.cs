using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
    public static class SessionData
    {
        public static int level;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

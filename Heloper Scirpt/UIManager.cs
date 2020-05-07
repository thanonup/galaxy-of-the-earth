using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject obj_UIOnlose;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void OnLose()
    {
        obj_UIOnlose.SetActive(true);
    }

}

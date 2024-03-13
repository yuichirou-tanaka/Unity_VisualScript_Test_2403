using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomEventTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CustomEvent.Trigger(gameObject, "TestEvt1", "ScriptToGraph");
    }


}

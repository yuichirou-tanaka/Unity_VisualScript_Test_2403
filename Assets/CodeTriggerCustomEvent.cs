using Unity.VisualScripting;
using UnityEngine;


public class CodeTriggerCustomEvent : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //Trigger the previously created Custom Scripting Event MyCustomEvent with the integer value 2.
            EventBus.Trigger(EventNames.MyCustomEvent, 2);
        }
    }
}
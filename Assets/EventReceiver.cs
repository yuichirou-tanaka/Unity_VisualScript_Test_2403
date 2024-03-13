using Unity.VisualScripting;
using UnityEngine;

public class EventReceiver : MonoBehaviour
{
    void Start()
    {
        EventBus.Register<int>(EventNames.MyCustomEvent, i =>
        {
            Debug.Log("RECEIVED " + i);
        });
    }
}
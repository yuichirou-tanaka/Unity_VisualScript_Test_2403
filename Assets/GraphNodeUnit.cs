using UnityEngine;
using Unity.VisualScripting;

public class GraphNodeUnit : Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;

    [DoNotSerialize]
    public ControlOutput outputTrigger;


    protected override void Definition()
    {
        inputTrigger = ControlInput("inputTrigger", (flow) => { return outputTrigger; });
        outputTrigger = ControlOutput("outputTrigger");
        Debug.Log("GraphNodeUnit  Definition");
    }
}

using Unity.VisualScripting;

//イベントを送信するカスタムノード
[UnitTitle("Send My custom Event")]
[UnitCategory("Events\\MyEvents")]//ファジーファインダーでノードを特定するパスを Events > My Events に設定します。
public class SendMyEvent : Unit
{
    [DoNotSerialize]// シリアル化すべきでないデータをシリアル化しないようにするための必須の属性です。
    [PortLabelHidden]// デフォルトの Input Trigger と Output Trigger のラベルは通常非表示にするので、ポートラベルを非表示にします。
    public ControlInput inputTrigger { get; private set; }
    [DoNotSerialize]
    public ValueInput myValue;
    [DoNotSerialize]
    [PortLabelHidden]// デフォルトの Input Trigger と Output Trigger のラベルは通常非表示にするので、ポートラベルを非表示にします。
    public ControlOutput outputTrigger { get; private set; }

    protected override void Definition()
    {

        inputTrigger = ControlInput(nameof(inputTrigger), Trigger);
        myValue = ValueInput<int>(nameof(myValue), 1);
        outputTrigger = ControlOutput(nameof(outputTrigger));
        Succession(inputTrigger, outputTrigger);
    }

    //イベント MyCustomEvent を ValueInput のポート myValueA からの int 値とともに送信します。
    private ControlOutput Trigger(Flow flow)
    {
        EventBus.Trigger(EventNames.MyCustomEvent, flow.GetValue<int>(myValue));
        return outputTrigger;
    }
}
using Unity.VisualScripting;
using UnityEngine;

//カスタムイベントの文字列名を登録してそれをイベントにフックします。このクラスは別ファイルに保存でき、複数のイベントをパブリックな静的文字列として追加することができます。
public static class EventNames
{
    public static string MyCustomEvent = "MyCustomEvent";
}

[UnitTitle("On my Custom Event")]//イベントを受け取る Custom Event ノード。イベントの命名規則に従ってノードのタイトルに On を追加しています。
[UnitCategory("Events\\MyEvents")]//ファジーファインダー内でノードを特定するパスを Events > My Events に設定しています。
public class MyCustomEvent : EventUnit<int>
{
    [DoNotSerialize]// ポートのシリアル化は不要です。
    public ValueOutput result { get; private set; }// イベントがトリガーされた時に返される、イベントの出力データです。
    protected override bool register => true;

    // EventHook をイベント名とともに Visual Scripting イベントのリストに追加します。
    public override EventHook GetHook(GraphReference reference)
    {
        return new EventHook(EventNames.MyCustomEvent);
    }
    protected override void Definition()
    {
        base.Definition();
        // ポートに値を設定します。
        result = ValueOutput<int>(nameof(result));
    }
    // ポートに値を設定します。
    protected override void AssignArguments(Flow flow, int data)
    {
        flow.SetValue(result, data);
    }
}
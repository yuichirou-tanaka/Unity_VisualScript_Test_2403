using Unity.VisualScripting;
using UnityEngine;

//�J�X�^���C�x���g�̕����񖼂�o�^���Ă�����C�x���g�Ƀt�b�N���܂��B���̃N���X�͕ʃt�@�C���ɕۑ��ł��A�����̃C�x���g���p�u���b�N�ȐÓI������Ƃ��Ēǉ����邱�Ƃ��ł��܂��B
public static class EventNames
{
    public static string MyCustomEvent = "MyCustomEvent";
}

[UnitTitle("On my Custom Event")]//�C�x���g���󂯎�� Custom Event �m�[�h�B�C�x���g�̖����K���ɏ]���ăm�[�h�̃^�C�g���� On ��ǉ����Ă��܂��B
[UnitCategory("Events\\MyEvents")]//�t�@�W�[�t�@�C���_�[���Ńm�[�h����肷��p�X�� Events > My Events �ɐݒ肵�Ă��܂��B
public class MyCustomEvent : EventUnit<int>
{
    [DoNotSerialize]// �|�[�g�̃V���A�����͕s�v�ł��B
    public ValueOutput result { get; private set; }// �C�x���g���g���K�[���ꂽ���ɕԂ����A�C�x���g�̏o�̓f�[�^�ł��B
    protected override bool register => true;

    // EventHook ���C�x���g���ƂƂ��� Visual Scripting �C�x���g�̃��X�g�ɒǉ����܂��B
    public override EventHook GetHook(GraphReference reference)
    {
        return new EventHook(EventNames.MyCustomEvent);
    }
    protected override void Definition()
    {
        base.Definition();
        // �|�[�g�ɒl��ݒ肵�܂��B
        result = ValueOutput<int>(nameof(result));
    }
    // �|�[�g�ɒl��ݒ肵�܂��B
    protected override void AssignArguments(Flow flow, int data)
    {
        flow.SetValue(result, data);
    }
}
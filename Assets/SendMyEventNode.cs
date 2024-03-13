using Unity.VisualScripting;

//�C�x���g�𑗐M����J�X�^���m�[�h
[UnitTitle("Send My custom Event")]
[UnitCategory("Events\\MyEvents")]//�t�@�W�[�t�@�C���_�[�Ńm�[�h����肷��p�X�� Events > My Events �ɐݒ肵�܂��B
public class SendMyEvent : Unit
{
    [DoNotSerialize]// �V���A�������ׂ��łȂ��f�[�^���V���A�������Ȃ��悤�ɂ��邽�߂̕K�{�̑����ł��B
    [PortLabelHidden]// �f�t�H���g�� Input Trigger �� Output Trigger �̃��x���͒ʏ��\���ɂ���̂ŁA�|�[�g���x�����\���ɂ��܂��B
    public ControlInput inputTrigger { get; private set; }
    [DoNotSerialize]
    public ValueInput myValue;
    [DoNotSerialize]
    [PortLabelHidden]// �f�t�H���g�� Input Trigger �� Output Trigger �̃��x���͒ʏ��\���ɂ���̂ŁA�|�[�g���x�����\���ɂ��܂��B
    public ControlOutput outputTrigger { get; private set; }

    protected override void Definition()
    {

        inputTrigger = ControlInput(nameof(inputTrigger), Trigger);
        myValue = ValueInput<int>(nameof(myValue), 1);
        outputTrigger = ControlOutput(nameof(outputTrigger));
        Succession(inputTrigger, outputTrigger);
    }

    //�C�x���g MyCustomEvent �� ValueInput �̃|�[�g myValueA ����� int �l�ƂƂ��ɑ��M���܂��B
    private ControlOutput Trigger(Flow flow)
    {
        EventBus.Trigger(EventNames.MyCustomEvent, flow.GetValue<int>(myValue));
        return outputTrigger;
    }
}
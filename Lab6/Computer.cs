namespace Lab6;

public class Computer
{
    private bool isOn;

    public bool IsOn
    {
        get => isOn;
        set => isOn = value;
    }

    public void TurnOn()
    {
        IsOn = true;
    }

    public void TurnOff()
    {
        IsOn = false;
    }
}
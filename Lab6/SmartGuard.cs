namespace Lab6;

public class SmartGuard : SmartDoor
{
    private Siren siren;

    public SmartGuard()
    {
        siren = new Siren();
    }

    public void ActivateSiren()
    {
        siren.Activate();
    }

    public void DeactivateSiren()
    {
        siren.Deactivate();
    }

    public void SendAlert(string number, string message)
    {
        MobileConnection.SendSMS(number, message);
    }
}
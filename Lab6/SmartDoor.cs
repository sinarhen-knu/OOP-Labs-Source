namespace Lab6;

public class SmartDoor
{
    private Computer computer;
    private Visualizer visualizer;
    private Projector projector;
    private BodyScanner bodyScanner;
    private InteractiveTouchDisplay interactiveTouchDisplay;
    private Software software;
    private Sensor sensor;
    private Camera camera;
    private SoundGenerator soundGenerator;
    private MobileConnection mobileConnection;

    public delegate void DoorOpenedEventHandler(object source, EventArgs args);
    public event DoorOpenedEventHandler OnDoorOpened;

    
    public bool RecognizePerson(string person)
    {
        Console.WriteLine($"Recognizing {person}...");
        return true;  
    }

    public void Alert()
    {
        Console.WriteLine("Alert! Unauthorized person detected.");
    }

    public void OpenDoor()
    {
        if (RecognizePerson("John Doe"))
        {
            try
            {
                OnDoorOpened?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while opening the door: " + ex.Message);
            }
        }
        else
        {
            Alert();
        }
    }
}
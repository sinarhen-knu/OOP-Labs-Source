using Lab5;
namespace Lab5;

public class EnterpriseArray
{
    private Enterprise[] enterprises;

    public EnterpriseArray(int size)
    {
        enterprises = new Enterprise[size];
    }

    public Enterprise this[int index]
    {
        get
        {
            return enterprises[index];
        }
        set
        {
            enterprises[index] = value;
        }
    }
}


public interface AirTrain
{
    // Property
    int TrainNumber { get; set; }

    // Indexer
    string this[int index]
    {
        get;
    }

    // Event
    event EventHandler TrainEvent;
    void TrainArrived();
}

class Train : AirTrain
{
    public int TrainNumber { get; set; }

    private string[] arr = new string[]
    {"Terminals 1&2", "Terminal 4", "Terminal 5", "Terminal 7","Terminal 8"};

    public string this[int index]
    {
        get => arr[index];
    }

    public event EventHandler TrainEvent;

    public void TrainArrived()
    {
        OnTrainArrival(new EventArgs());
        Random r = new Random();
        var s = r.Next(0, 4);
        Console.WriteLine($"Train '{TrainNumber}' arrived at '{this[s]}'");
    }

    void OnTrainArrival(EventArgs e)
    {
        if (TrainEvent != null)
            TrainEvent(this, e);
    }
}


class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();
        int t = r.Next(1, 10);
        AirTrain train1 = new Train();
        train1.TrainNumber = t;
        train1.TrainArrived();
    }
}
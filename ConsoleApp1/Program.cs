// See https://aka.ms/new-console-template for more information

interface IHuman
{
    string Name { get; set; }
    int Age { get; }
    int PrivateId { set { PrivateId = value; } }


}
class Human: IHuman
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private int age = 21;
    public int Age
    {
        get { return age; }
    }
    private int publicId;
    public int PublicId
    {
        set { publicId = value; }
    }

    
    //defining the delegate
    public delegate void SpeakHandeler(object soruce, EventArgs args);

    public event SpeakHandeler Speak;
    public void prepareSpeak()
    {
        Console.WriteLine("preparing to speak please wait");
        Thread.Sleep(1000);

        onSpeak();
    }
    protected virtual void onSpeak()
    {
        if (Speak != null)
        {
            Speak(this, null);
        }
    }
    //defining the properties from inheritance

    


}
public class Service
{
    public void onSpeak(object soruce, EventArgs eventArgs)
    {
        Console.WriteLine("I can speak");
    }
}
class program
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        var human = new Human {Name = "Bob", PublicId=1};

        Console.WriteLine("Made object");

        var service = new Service();
        human.Speak += service.onSpeak;
        human.prepareSpeak();
       Console.ReadKey();
        
    }

}
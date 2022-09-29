public class Car
{
    public string model { get; set; }
    private int _passengers;
    public int passengers
    {
        get
        {
            return _passengers;
        }
        set
        {
            if (value < 2)
            {
                Console.WriteLine("Hatalı bir yolcu sayısı değeri girdiniz. Yolcu sayısı değeri 2'den küçük olamaz");
            }
            else
            {
                _passengers = value;
            }
        }
    }
    public string color { get; set; }
    private float _speed;
    public float speed
    {
        get
        {
            return _speed;
        }
        set
        {
            if (value > 250)
            {
                Console.WriteLine("Hatalı bir hız değeri girdiniz. Hız değeri 250'den büyük değer alamaz");
            }
            else
            {
                _speed = value;
            }
        }
    }
    public Car(string model, int passengers, string color, float speed)
    {
        this.model = model;
        this.passengers = passengers;
        this.color = color;
        this.speed = speed;
    }

    public bool ComparePassengers(int passengers)
    {
        return passengers < this.passengers;
    }
    public Car CompareSpeed(Car car)
    {
        if (car.speed > this.speed)
        {
            return car;
        }
        else
        {
            return this;
        }
    }

    public string IntroduceSelf()
    {
        string brief = "Model: " + this.model + "#Passengers: " + this.passengers + "#Color: " + this.color + "#Speed: " + this.speed;
        brief = brief.Replace("#", System.Environment.NewLine);
        return brief;
    }
}

public class Program
{
    public static void Main()
    {
        Car car1 = new Car("BMW", 2, "black", 250f);
        Car car2 = new Car("Mitsubishi", 6, "grey", 180f);
        Car car3 = new Car("Renault", 4, "blue", 200f);
        Console.WriteLine(car1.speed + " " + car1.passengers);
        Console.WriteLine(car1.ComparePassengers(car2.passengers));
        Console.WriteLine(car2.CompareSpeed(car3).IntroduceSelf());
    }
}
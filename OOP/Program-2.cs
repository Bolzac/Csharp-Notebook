//will be updated
public abstract class Home
{
    public double price { get; set; }
    public string location { get; set; }
    public abstract double discountedPrice();
    public double getPrice()
    {
        return this.price;
    }
    public void setPrice(double price)
    {
        this.price = price;
    }
    public string getLocation()
    {
        return this.location;
    }
    public void setLocation(string location)
    {
        this.location = location;
    }
}
class Customer
{
    string name { get; set; }
    string telephone { get; set; }
    string address { get; set; }
    List<Home> hm = new List<Home>();
    int homeCounter { get; set; }
    double payment { get; set; }
    public Customer(string name, string telephone, string address)
    {
        this.name = name;
        this.telephone = telephone;
        this.address = address;
    }
    public void buyHome(Home home)
    {
        hm.Add(home);
        this.setHomeCounter(1);
        if (this.getHomeCounter() >= 2) this.setPayment(home.discountedPrice());
        else this.setPayment(home.getPrice());
    }
    public void listHome()
    {
        Console.WriteLine("Customer's Homes:");
        foreach (Home item in hm)
        {
            Console.WriteLine(item);
        }
    }
    /*public void listLocations()
    {
        Console.WriteLine("Müşteri " + this.getName() + " lokasyonları: ");
        List<string> locations = new List<string>();
        locations.Clear();
        foreach (Home item in hm)
        {
            locations.Add(item.location);
            foreach (string location in locations)
            {
                if (item.getLocation() != location)
                {
                    locations.Add(item.location);
                }
            }
        }
        foreach (string location in locations)
        {
            int i = 0;
            foreach (Home item in hm)
            {
                if (item.getLocation() == location)
                {
                    i++;
                }
            }
            Console.WriteLine(location + " ----> " + i);
        }
    }*/
    public string getInfo()
    {
        return this.getName() + " isimli müşteri " + this.getHomeCounter() + " tane ev almıştır ve toplamda " + this.getPayment() + " ödemiştir.";
    }
    public string getName()
    {
        return this.name;
    }
    public void setName(string name)
    {
        this.name = name;
    }
    public string getTelephone()
    {
        return this.telephone;
    }
    public void setTelephone(string telephone)
    {
        this.telephone = telephone;
    }
    public string getAddress()
    {
        return this.address;
    }
    public void setAddress(string address)
    {
        this.address = address;
    }
    public int getHomeCounter()
    {
        return this.homeCounter;
    }
    public void setHomeCounter(int homeCounter)
    {
        this.homeCounter += homeCounter;
    }
    public double getPayment()
    {
        return this.payment;
    }
    public void setPayment(double payment)
    {
        this.payment += payment;
    }
}

class EstateAgent
{
    public string name { get; set; }
    List<Home> h = new List<Home>();
    public void hasHome(Home home)
    {
        h.Add(home);
    }
    public void listHome()
    {
        Console.WriteLine("Estate Agent's Homes:");
        foreach (Home item in h)
        {
            Console.WriteLine(item);
        }
    }
    public void sellHome(Home home, Customer customer)
    {
        h.Remove(home);
        customer.buyHome(home);
    }
    public string getName()
    {
        return this.name;
    }
    public void setName(string name)
    {
        this.name = name;
    }
}

class Apartment : Home
{
    public double dues { get; set; }
    public Apartment(double dues, double price, string location)
    {
        this.location = location;
        this.price = price;
        this.dues = dues;
    }
    public override double discountedPrice()
    {
        double price = this.getPrice() * (95 / 100);
        return price;
    }
    public double GetDues()
    {
        return this.dues;
    }
    public void setDues(double dues)
    {
        this.dues = dues;
    }
}

class Villa : Home
{
    public Villa(double price, string location)
    {
        this.location = location;
        this.price = price;
    }
    public override double discountedPrice()
    {
        double price = this.getPrice() * (95 / 100);
        return price;
    }
}
public class Program
{
    public static void Main()
    {
        Home villa = new Villa(1000, "üsküdar");
        Home apartment = new Apartment(200, 800, "mecidiyeköy");
        Home apartment2 = new Apartment(100, 600, "mecidiyeköy");
        EstateAgent ea = new EstateAgent();
        Customer customer = new Customer("Emirhan", "12345", "üsküdar");
        ea.hasHome(villa);
        ea.hasHome(apartment);
        ea.hasHome(apartment2);
        Console.WriteLine("Before sales");
        ea.listHome();
        ea.sellHome(villa, customer);
        Console.WriteLine("After sales");
        ea.listHome();
        customer.listHome();
        ea.sellHome(apartment, customer);
    }
}

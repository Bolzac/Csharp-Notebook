namespace System.Collections.Generic;
using System;
public interface IProcessManager
{
    public int GetUsedMemorySize();
    public void AddProcess(User u, string processname, int required_memory);
    public void RemoveProcess(string name);
    public void PrintProcesses();
    public void PrintWaitingProcesses();
}
public class ProcessManager : IProcessManager
{
    int used_memory_size = 0;
    int max_memory_size;
    Dictionary<string, Process> processMaps = new Dictionary<string, Process>();
    LinkedList<Process> waitingProcessList = new LinkedList<Process>();

    public ProcessManager(int max_memory_size)
    {
        this.max_memory_size = max_memory_size;
    }

    public int GetUsedMemorySize()
    {
        return used_memory_size;
    }
    public void AddProcess(User u, string processname, int required_memory)
    {
        // if (processMaps.ContainsKey(processname))
        // {
        //     throw new Exception("Process is existing!");
        // }
        // else
        // {
        Process process = new Process(processname, required_memory, u);
        if (max_memory_size >= GetUsedMemorySize() + required_memory)
        {
            processMaps.Add(processname, process);
        }
        else
        {
            waitingProcessList.AddLast(process);
        }
        //}
    }
    public void RemoveProcess(string name)
    {
        processMaps.Remove(name);
    }
    public void PrintProcesses()
    {
        foreach (var process in processMaps)
        {
            Console.Write("Name: " + process.Key + "\n" + "User: " + process.Value.GetUser());
        }
    }
    public void PrintWaitingProcesses()
    {
        foreach (var process in waitingProcessList)
        {
            Console.Write("Name: " + process.GetName());
        }
    }
}
public class User
{
    string name;
    public User(string name)
    {
        this.name = name;
    }
    public string GetName()
    {
        return this.name;
    }
    public string ToString()
    {
        return $"User Name: {GetName()}";
    }
}
public class Process
{
    string name;
    int required_memory;
    User user;
    public Process(string name, int required_memory, User user)
    {
        this.name = name;
        this.required_memory = required_memory;
        this.user = user;
    }
    public string GetName()
    {
        return this.name;
    }
    public int GetRequiredMemory()
    {
        return this.required_memory;
    }
    public User GetUser()
    {
        return user;
    }
    public string toString()
    {
        return $"Name: {GetName()}\n required memory: {GetRequiredMemory()}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        ProcessManager pm = new ProcessManager(10);
        User u1 = new User("u1");
        User u2 = new User("u2");
        User u3 = new User("u3");

        pm.AddProcess(u1, "Process1", 2);
        pm.AddProcess(u1, "Process4", 2);
        pm.AddProcess(u2, "Process2", 6);

        pm.AddProcess(u3, "Process3", 3);
        pm.AddProcess(u1, "Process6", 7);
        //pm.AddProcess(u2, "Process2", 4); //ayni isimde
        pm.AddProcess(u1, "Process5", 1);

        Console.WriteLine("1-Process ----------------------------------");
        pm.PrintProcesses();
        Console.WriteLine("1-Waiting Process --------------------------");
        pm.PrintWaitingProcesses();
        try
        {
            pm.RemoveProcess("Process2");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine("2-Process ----------------------------------");
        pm.PrintProcesses();
        Console.WriteLine("2-Waiting Process --------------------------");
        pm.PrintWaitingProcesses();

        Console.WriteLine(pm.GetUsedMemorySize());

        try
        {
            pm.RemoveProcess("OlmayanProcess");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
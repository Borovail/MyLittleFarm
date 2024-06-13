using UnityEngine;

public class CommandInvoker
{
    public void ExecuteCommand(Command command)
    {
        command.Execute();
        Debug.Log($"Command {command.GetType().Name} executed");
    }
}

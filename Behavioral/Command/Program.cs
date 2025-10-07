using System;
using System.Collections.Generic;

namespace Command
{
    // Command interface
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Receiver
    public class Light
    {
        // Using C# 14 field keyword for cleaner implementation
        public string Location
        {
            get;
            init => field = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Light(string location)
        {
            Location = location;
        }

        public void TurnOn()
        {
            Console.WriteLine($"{Location} light is ON");
        }

        public void TurnOff()
        {
            Console.WriteLine($"{Location} light is OFF");
        }
    }

    // Concrete Commands
    public class LightOnCommand : ICommand
    {
        private Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOn();
        }

        public void Undo()
        {
            light.TurnOff();
        }
    }

    public class LightOffCommand : ICommand
    {
        private Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOff();
        }

        public void Undo()
        {
            light.TurnOn();
        }
    }

    // Invoker
    public class RemoteControl
    {
        private ICommand command;
        private Stack<ICommand> commandHistory = new Stack<ICommand>();

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            command.Execute();
            commandHistory.Push(command);
        }

        public void PressUndo()
        {
            if (commandHistory.Count > 0)
            {
                ICommand lastCommand = commandHistory.Pop();
                lastCommand.Undo();
            }
            else
            {
                Console.WriteLine("Nothing to undo");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Command Pattern Demo ===\n");

            // Receivers
            Light livingRoomLight = new Light("Living Room");
            Light kitchenLight = new Light("Kitchen");

            // Commands
            ICommand livingRoomOn = new LightOnCommand(livingRoomLight);
            ICommand livingRoomOff = new LightOffCommand(livingRoomLight);
            ICommand kitchenOn = new LightOnCommand(kitchenLight);
            ICommand kitchenOff = new LightOffCommand(kitchenLight);

            // Invoker
            RemoteControl remote = new RemoteControl();

            // Execute commands
            Console.WriteLine("Turning on living room light:");
            remote.SetCommand(livingRoomOn);
            remote.PressButton();

            Console.WriteLine("\nTurning on kitchen light:");
            remote.SetCommand(kitchenOn);
            remote.PressButton();

            Console.WriteLine("\nTurning off living room light:");
            remote.SetCommand(livingRoomOff);
            remote.PressButton();

            Console.WriteLine("\nUndo last command:");
            remote.PressUndo();

            Console.WriteLine("\nUndo previous command:");
            remote.PressUndo();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

using System;

namespace NETCore.App.Contracts
{
    public class AddProductCommand : ICommand
    {
        public AddProductCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}

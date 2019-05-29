using System;

namespace Source
{
    public abstract class Employee
    {
        public string Name { get; set; }

        public bool ContainsIllegalChars()
        {
            return this.Name.Contains("$");
        }
    }

    public class Manager : Employee { }

    public class DeliveryManager : Employee { }
}

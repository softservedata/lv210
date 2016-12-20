namespace DeveloperTask
{
    public class Builder : IDeveloper
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Tool { get; set; }
        public double Salary { get; private set; }
        public Builder(string name, string surname, string tool, double salary)
        {
            this.Name = name;
            this.Surname = surname;
            this.Tool = tool;
            this.Salary = salary;
        }
        public string Create()
        {
            return "";//$"Builder {Name} {Surname} is created.";
        }

        public string Destroy()
        {
            var currentProgrammerData = "";//$"Builder {Name} {Surname} is destroyed.";
            this.Name = null;
            this.Surname = null;
            this.Tool = null;
            this.Salary = double.NaN;

            return currentProgrammerData;
        }
    }
}

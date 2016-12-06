namespace HomeWork2_Task4
{
    public struct Dog
    {
        public string Name;
        public string Mark;
        public int Age;

        public override string ToString()
        {
            return string.Format("Dog name is : {0}, dog mark is : {1}, dog age is : {2}", Name, Mark, Age);
        }
    }
}

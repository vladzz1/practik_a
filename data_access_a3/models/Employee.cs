namespace data_access_a3.models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? HireDate { get; set; }
        public char Gender { get; set; }
        public float Salary { get; set; }
        public override string ToString()
        {
            return $"{FullName,15}  {HireDate,15} {Gender,5} {Salary,5}";
        }
    }
}

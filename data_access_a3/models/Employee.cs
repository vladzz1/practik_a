namespace data_access_a3.models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime HireDate { get; set; }
        public string? Gender { get; set; }
        public decimal Salary { get; set; }
        public override string ToString()
        {
            return $"{FullName,15}  {HireDate,15} {Gender,5} {Salary,5}";
        }
    }
}

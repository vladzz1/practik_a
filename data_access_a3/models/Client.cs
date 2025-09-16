namespace data_access_a3.models
{
    public class Client
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public int PercentSale { get; set; }
        public bool Subscribe { get; set; }
        public override string ToString()
        {
            return $"{FullName,15}  {Email,15} {Phone,5} {Gender,5} {PercentSale,15} {Subscribe,5}";
        }
    }
}

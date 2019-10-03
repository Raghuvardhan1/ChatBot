namespace CustomesDataModelLib
{
    public class CustomersDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Contact  { get; set; }
        public string Region { get; set; }
        public override string ToString()
        {
            return "{CustomerName},{CustomerId},{Contact},{Region}";
        }
    }
}

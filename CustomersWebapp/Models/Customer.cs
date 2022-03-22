namespace CustomersWebapp.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; } 

        public string Phone { get; set; } 
        
        public string Department { get; set; }

        public int ManagerId { get; set; }


    }
}

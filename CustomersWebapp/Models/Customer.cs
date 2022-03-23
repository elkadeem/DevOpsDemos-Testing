namespace CustomersWebapp.Models
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        //Add Comment
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; } 

        public string Phone { get; set; } 
        
        public string Department { get; set; }

        public int ManagerId { get; set; }


    }
}

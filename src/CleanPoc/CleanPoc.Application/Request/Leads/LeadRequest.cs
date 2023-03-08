namespace CleanPoc.Application.Request.Leads;

public abstract class LeadRequest
{
   public class Create
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        
        public string UserId { get; set; }
        
    }

   public class Update : Create
   {
       
   }
    
   
    
        
}
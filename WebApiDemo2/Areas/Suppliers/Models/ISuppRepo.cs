using WebApiDemo2.Models;

namespace WebApiDemo2.Areas.Suppliers.Models
{
    public interface ISuppRepo
    {

        void Enroll(SuppModel model);

        void Update(int id,SuppModel model);
        

    }

    public class SuppRepo : ISuppRepo
    {
        NorthwindDataContext _context;

        public SuppRepo(NorthwindDataContext context)
        {
                _context=context;

        }
        public void Enroll(SuppModel model)
        {
            _context.Suppliers.Add(model);  
            _context.SaveChanges(); 
        }

        public void Update(int id, SuppModel model)
        {
            SuppModel s=_context.Suppliers.Find(id);
            s.CompanyName= model.CompanyName;   
            s.City= model.City;
            _context.SaveChanges();
        }
    }
}

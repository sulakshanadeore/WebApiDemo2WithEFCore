namespace WebApiDemo2.Models
{
    public interface ICategoryRepo
    {
        List<CategoryModel> GetAll();

        CategoryModel FindByCategoryID(int id);

        CategoryModel FindByIDAndName(int id, string name);

        void UpdateCategory(int id, CategoryModel model);

        void DeleteCategory(int id);

        void AddCategory(CategoryModel category);
    }
    public class CategoryRepo : ICategoryRepo
    {
        NorthwindDataContext _context;
        public CategoryRepo(NorthwindDataContext context)
        {
            _context = context;
        }



        public void AddCategory(CategoryModel category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }


        public CategoryModel FindByIDAndName(int id, string name)
        {
            CategoryModel model = _context.Categories.Where(c => c.CategoryID == id && c.CategoryName == name)
                .FirstOrDefault();
            return model;


        }
        public CategoryModel FindByCategoryID(int id)
        {
            return _context.Categories.Find(id);
        }

        public List<CategoryModel> GetAll()
        {

            return _context.Categories.ToList();
        }

        public void UpdateCategory(int id, CategoryModel model)
        {

            CategoryModel m = _context.Categories.Find(id);
            m.CategoryName = model.CategoryName;
            m.Description = model.Description;
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            CategoryModel m = _context.Categories.Find(id);
            _context.Categories.Remove(m);
            _context.SaveChanges();

        }
    }
}

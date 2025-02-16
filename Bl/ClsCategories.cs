using LapShopPr.Models;


namespace LapShopPr.Bl

{
    public interface ICategories
    {
        public List<TbCategory> GetAll();
        public TbCategory GetById(int id);
        public bool Save(TbCategory category);
        public bool Delete(int id);
    }
 


    public class ClsCategories:ICategories
    {

        LapShopContext context;
        public ClsCategories(LapShopContext  ctx)
        {
            context = ctx;
        }

        public List<TbCategory> GetAll()
        {
            try
            {

                var lstCategories = context.TbCategories.Where(a => a.CurrentState == 1).ToList();
                return lstCategories;
            }
            catch { 
            
            
            return new List<TbCategory>();
            
            }
        }

        public TbCategory GetById(int id)
        {

            try
            {
               
              var  Category = context.TbCategories.FirstOrDefault(a => a.CategoryId == id);

                return Category;
                
            }
            catch
            {
                return new TbCategory();
            }
        }

        public bool Save(TbCategory category)
        {

            try
            {

 
               
                if (category.CategoryId == 0)
                {
                    category.CreatedBy = "1";
                    category.CreatedDate = DateTime.Now;
                    context.TbCategories.Add(category);
                }
                else
                {
                    category.CreatedBy = "1";
                    category.CreatedDate = DateTime.Now;
                    context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return  true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var Category = GetById(id);
              
                context.TbCategories.Remove(Category);
                context.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }

    }
}

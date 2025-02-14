using Domains;
using LapShopPr.Models;

namespace LapShopPr.Bl
{

    public interface IPages
    {
        public List<TbPages> GetAll();
      
        public List<VwItem> GetAllItemData(int? Categoryid);
        public TbPages GetById(int id);
        public VwItem GetItemId(int id);

        public bool Save(TbPages item);
        public bool Delete(int id);

    }
    public class ClsPages:IPages
    {


        LapShopContext context;
        public ClsPages(LapShopContext ctx)
        {
            context = ctx;
        }
        public List<TbPages>GetAll()
        {
            try
            {
                
                var item = context.TbPages.ToList();
                return item;
            }
            catch
            {


                return new List<TbPages>();

            }
        }

      

        public List<VwItem> GetAllItemData(int ? Categoryid)
           
        {
            try
            {
                var item = context.VwItems.Where(a=>(a.CategoryId==Categoryid||Categoryid==null||Categoryid==0&&!string.IsNullOrEmpty(a.ItemName))).ToList();
                return item;
            }
            catch
            {


                return new List<VwItem>();

            }
        }
     
        public TbPages GetById(int id)
        {

            try
            {
               
                var item = context.TbPages.FirstOrDefault(a => a.PageId == id);

                return item;

            }
            catch
            {
                return new TbPages();
            }
        }
        public VwItem GetItemId(int id)
        {

            try
            {

                var item = context.VwItems.FirstOrDefault(a => a.ItemId == id);

                return item;

            }
            catch
            {
                return new VwItem();
            }
        }
        public bool Save(TbPages item)
        {

            try
            {

               

                if (item.PageId == 0)
                {
                    item.CreatedBy = "1";
                    item.CreatedDate = DateTime.Now;
                    context.TbPages.Add(item);
                }
                else
                {
                    item.CreatedBy = "1";
                    item.CreatedDate = DateTime.Now;
                    context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
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
                var item = GetById(id);
              
                context.TbPages.Remove(item);
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

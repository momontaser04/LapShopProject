using LapShopPr.Models;

namespace LapShopPr.Bl
{

    public interface IItem
    {
        public List<TbItem> GetAll();
      
        public List<VwItem> GetAllItemData(int? Categoryid);
        public TbItem GetById(int id);
        public VwItem GetItemId(int id);
        public List<VwItem> GetRecommendedItem(int id);
        public bool Save(TbItem item);
        public bool Delete(int id);

    }
    public class ClsItem:IItem
    {


        LapShopContext context;
        public ClsItem(LapShopContext ctx)
        {
            context = ctx;
        }
        public List<TbItem>GetAll()
        {
            try
            {
                
                var item = context.TbItems.ToList();
                return item;
            }
            catch
            {


                return new List<TbItem>();

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
        public List<VwItem> GetRecommendedItem(int id)

        {
           
            try
            {
                var item=GetById(id);
               var lstcategory = context.VwItems.Where(a => (a.SalesPrice>item.SalesPrice-200&&a.SalesPrice<item.SalesPrice+50)).ToList();
                return lstcategory;
            }
            catch
            {


                return new List<VwItem>();

            }
        }
        public TbItem GetById(int id)
        {

            try
            {
               
                var item = context.TbItems.FirstOrDefault(a => a.ItemId == id);

                return item;

            }
            catch
            {
                return new TbItem();
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
        public bool Save(TbItem item)
        {

            try
            {

               

                if (item.ItemId == 0)
                {
                    item.CreatedBy = "1";
                    item.CreatedDate = DateTime.Now;
                    context.TbItems.Add(item);
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
              
                context.TbItems.Remove(item);
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

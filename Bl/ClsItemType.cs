using LapShopPr.Models;


namespace LapShopPr.Bl

{
    public interface IItemType
    {
        public List<TbItemType> GetAll();
        public TbItemType GetById(int id);
        public bool Save(TbItemType itemtype);

        public bool Delete(int id);

    }
 
    public class ClsItemType:IItemType
    {

        LapShopContext context;
        public ClsItemType(LapShopContext ctx)
        {
            context = ctx;
        }
        public List<TbItemType> GetAll()
        {
            try
            {
               
                var itemtype = context.TbItemTypes.ToList();
                return itemtype;
            }
            catch { 
            
            
            return new List<TbItemType>();
            
            }
        }

        public TbItemType GetById(int id)
        {

            try
            {
                
              var  itemtype = context.TbItemTypes.FirstOrDefault(a => a.ItemTypeId == id);

                return itemtype;
                
            }
            catch
            {
                return new TbItemType();
            }
        }

        public bool Save(TbItemType itemtype)
        {

            try
            {

            
               
                if (itemtype.ItemTypeId == 0)
                {
                    itemtype.CreatedBy = "1";
                    itemtype.CreatedDate = DateTime.Now;
                    context.TbItemTypes.Add(itemtype);
                }
                else
                {
                    itemtype.CreatedBy = "1";
                    itemtype.CreatedDate = DateTime.Now;
                    context.Entry(itemtype).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var itemtype = GetById(id);
              
                context.TbItemTypes.Remove(itemtype);
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

using LapShopPr.Models;


namespace LapShopPr.Bl

{
 
    public interface IOs
    {
        public List<TbO> GetAll();
        public TbO GetById(int id);
        public bool Save(TbO Os);
        public bool Delete(int id);

    }
    public class ClsOs:IOs
    {
        LapShopContext context;
        public ClsOs(LapShopContext ctx)
        {
            context = ctx;
        }
        public List<TbO> GetAll()
        {
            try
            {
               
                var Os = context.TbOs.ToList();
                return Os;
            }
            catch { 
            
            
            return new List<TbO>();
            
            }
        }

        public TbO GetById(int id)
        {

            try
            {
               
              var  Os = context.TbOs.FirstOrDefault(a => a.OsId == id);

                return Os;
                
            }
            catch
            {
                return new TbO();
            }
        }

        public bool Save(TbO Os)
        {

            try
            {

               
               
                if (Os.OsId == 0)
                {
                    Os.CreatedBy = "1";
                    Os.CreatedDate = DateTime.Now;
                    context.TbOs.Add(Os);
                }
                else
                {
                    Os.CreatedBy = "1";
                    Os.CreatedDate = DateTime.Now;
                    context.Entry(Os).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var Os = GetById(id);
              
                context.TbOs.Remove(Os);
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

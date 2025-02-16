using LapShopPr.Models;


namespace LapShopPr.Bl

{
 
    public interface ISlider
    {
        public List<TbSlider> GetAll();
        public TbSlider GetById(int id);
        public bool Save(TbSlider Os);
        public bool Delete(int id);

    }
    public class ClsSlider: ISlider
    {
        LapShopContext context;
        public ClsSlider(LapShopContext ctx)
        {
            context = ctx;
        }
        public List<TbSlider> GetAll()
        {
            try
            {
               
                var Os = context.TbSliders.ToList();
                return Os;
            }
            catch { 
            
            
            return new List<TbSlider>();
            
            }
        }

        public TbSlider GetById(int id)
        {

            try
            {
               
              var  Os = context.TbSliders.FirstOrDefault(a => a.SliderId == id);

                return Os;
                
            }
            catch
            {
                return new TbSlider();
            }
        }

        public bool Save(TbSlider Os)
        {

            try
            {

               
               
                if (Os.SliderId == 0)
                {
                    Os.CreatedBy = "1";
                    Os.CreatedDate = DateTime.Now;
                    context.TbSliders.Add(Os);
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
              
                context.TbSliders.Remove(Os);
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

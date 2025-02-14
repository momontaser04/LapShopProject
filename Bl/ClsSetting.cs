using LapShopPr.Models;


namespace LapShopPr.Bl

{
    public interface ISettings
    {
        public TbSettings GetAll();
       
        public bool Save(TbSettings itemtype);

        

    }
 
    public class ClsSetting : ISettings
    {

        LapShopContext context;
        public ClsSetting(LapShopContext ctx)
        {
            context = ctx;
        }
        public TbSettings GetAll()
        {
            try { 
                var itemtype = context.TbSettings.FirstOrDefault();
                return itemtype;
			}
            catch
            {

                return new TbSettings();
            }



		}

        public bool Save(TbSettings itemtype)
        {

            try
            {

            
                context.SaveChanges();
                return  true;
            }
            catch
            {
                return false;
            }
        }

       

    }
}

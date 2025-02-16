using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapShopPr.Models
{
    public class TbSettings
    {

        [Key]
    public int Id {  get; set; }

        public string WebsiteName { get; set; }
        public string Logo { get; set; }
        public string WebsiteDescription { get; set; }
        public string FaceBookLink { get; set; }
        public string LinkedIn { get; set; }
        public string GithubLink { get; set; }
        public string YoutubeLink { get; set; }
        public string GmailLink { get; set; }

        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string MiddlePanner { get; set; }
        





    }
}

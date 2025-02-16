namespace LapShopPr.Utlities
{
    public static class Helper
    {


        public static async Task<string> UploadImage(List<IFormFile> Files,string FolderName)
        {
            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg"; // Updated for unique names
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads\"+FolderName, ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                        return ImageName;
                    }
                }
            }
            return string.Empty;
        }
    }
}

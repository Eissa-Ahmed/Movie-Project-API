namespace Movie.BL.Helper
{
    public static class FileManager
    {
        public static string UploadFile(string FolderName, IFormFile file)
        {
            var pathFolder = Directory.GetCurrentDirectory() + "/Files/" + FolderName;
            var FileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
            var finalPath = Path.Combine(pathFolder, FileName);

            using (var Stream = new FileStream(finalPath, FileMode.Create))
            {
                file.CopyTo(Stream);
                if (File.Exists(finalPath))
                {
                    return FileName;
                }
                else
                {
                    throw new Exception("File Not Uploaded");
                }
            }

        }

        public static bool DeleteFile(string FolderName, string FileName)
        {
            var path = Directory.GetCurrentDirectory() + "/Files/" + FolderName + FileName;
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string? CheckFile(IFormFile file)
        {
            var ListExtension = new List<string>() { ".png", ".jpg" };
            int SizeOfFile = 1048576;
            if (!ListExtension.Contains(Path.GetExtension(file.FileName).ToLower()))
                return "Supported Extensions is (.png , .Jpg)";

            if (file.Length > SizeOfFile)
                return "Supported Size is 1MB";

            return null;
        }
    }
}

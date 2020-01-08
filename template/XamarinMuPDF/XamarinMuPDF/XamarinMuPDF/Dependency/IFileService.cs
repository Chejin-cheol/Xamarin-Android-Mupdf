using System;
using System.Collections.Generic;
using System.Text;
using XamarinMuPDF.Model;

namespace XamarinMuPDF.Dependency
{
    public interface IFileService
    {
        List<Item> GetFileList(string type);
    }
}

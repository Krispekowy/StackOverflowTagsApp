using StackOverflowTagsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowTagsApp.Interfaces
{
    public interface ITagsFromSite
    {
        Task<string> GetTagsJSON(int page);
        TagsListModel DeserializeJSON(string JSONresult);
        List<TagModel> GetTagsTOP();
        List<TagModel> CheckShare(List<TagModel> tagsList);
    }
}

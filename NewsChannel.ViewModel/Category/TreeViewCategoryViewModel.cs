using System.Collections.Generic;

namespace NewsChannel.ViewModel.Category
{
    public class TreeViewCategory
    {
        public TreeViewCategory()
        {
            Subs = new List<TreeViewCategory>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TreeViewCategory> Subs { get; set; }
    }
}

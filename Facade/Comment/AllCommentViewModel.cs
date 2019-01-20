using System.Collections.Generic;
using Facade.Common;
using Facade.Event;

namespace Facade.Comment
{
    public class AllCommentViewModel : BasicViewModel
    {
        public EventViewModel EventViewModel { get; set; }

        public List<CommentProfileViewModel> CommentProfileViewModel { get; set; }
    }
}

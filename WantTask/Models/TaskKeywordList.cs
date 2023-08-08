using System;
using System.Collections.Generic;

namespace WantTask.Models;

public partial class TaskKeywordList
{
    public int TaskKeywordListId { get; set; }

    public int? CaseId { get; set; }

    public int? KeywordId { get; set; }

    public virtual TaskList? Case { get; set; }

    public virtual Keyword? Keyword { get; set; }
}

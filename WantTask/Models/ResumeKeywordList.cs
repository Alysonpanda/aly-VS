﻿using System;
using System.Collections.Generic;

namespace WantTask.Models;

public partial class ResumeKeywordList
{
    public int ResumeKeywordListId { get; set; }

    public int? ResumeId { get; set; }

    public int? KeywordId { get; set; }

    public virtual Keyword? Keyword { get; set; }

    public virtual Resume? Resume { get; set; }
}

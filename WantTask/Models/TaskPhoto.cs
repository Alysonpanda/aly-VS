using System;
using System.Collections.Generic;

namespace WantTask.Models;

public partial class TaskPhoto
{
    public int TaskPhotoId { get; set; }

    public int CaseId { get; set; }

    public byte[]? Photo { get; set; }

    public virtual TaskList Case { get; set; } = null!;
}

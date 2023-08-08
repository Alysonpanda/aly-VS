using System;
using System.Collections.Generic;

namespace WantTask.Models;

public partial class CertificateType
{
    public int CertificateTypeId { get; set; }

    public string? CertificateTypeName { get; set; }

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
}

using System;

namespace NGWebV1.Models
{
    public abstract class CamposAuditoria
    {
        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }

        public CamposAuditoria()
        {
            CreationTime = DateTime.Now;
        }
    }
}
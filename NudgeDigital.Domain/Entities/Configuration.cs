using NudgeDigital.Domain.Common;

namespace NudgeDigital.Domain.Entities
{
    public class Configuration: AuditableEntity
    {
        public int ComponentId { get; set; }
        public Component Component { get; set; }
        public string ComponentType { get; set; }
        public decimal Price { get; set; }
    }
}

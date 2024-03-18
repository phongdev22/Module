using System.ComponentModel.DataAnnotations;

namespace Module.Entities
{
    public class EventConfiguration
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string IdentityCode { get; set; }
        public required string EventName { get; set; }
        public required string TemplateCode { get; set; }
        public required string RouteRule { get; set; }
        //public required string Script { get; set; } = "";
        public required string ListParams { get; set; } = "";
    }
}
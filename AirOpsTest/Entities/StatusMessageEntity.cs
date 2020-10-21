using System;

namespace AirOpsTest.Entities
{
    public class StatusMessageEntity: BaseEntity
    {
        public DateTime StatusDate { get; set; }
        public string Message { get; set; }
    }
}
using System;
using AirOpsTest.Interfaces;

namespace AirOpsTest.DtoS
{
    public class StatusMessageModel: IBaseModel
    {
        public int Id { get; set; }
        public DateTime StatusDate { get; set; }
        public string Message { get; set; }
    }
}
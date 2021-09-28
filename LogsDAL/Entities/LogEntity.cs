using System;

namespace LogsDAL.Entities
{
    public class LogEntity
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public DateTime DateTimeRequest { get; set; }
        public double Code { get; set; }
        public double Size { get; set; }
     
    }
}

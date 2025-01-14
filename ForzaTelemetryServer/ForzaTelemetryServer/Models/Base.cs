using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ForzaTelemetryServer.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        [Timestamp]
        public DateTime Created { get; set; }
        [Timestamp]
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
    }
}

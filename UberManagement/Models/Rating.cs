using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UberManagement.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Range(1,5)]
        public int Score { get; set; }
        [MaxLength(250)]
        public string Comment { get; set; }
        public Ride Ride { get; set; }
        //[Required, ForeignKey(nameof(Ride))]
        public int RideId { get; set; }
    }
}

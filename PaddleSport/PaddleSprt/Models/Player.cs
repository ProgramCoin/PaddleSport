using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace PaddleSprt.Models
{
    public class Booking
    {
        SportCenter sCenter = new SportCenter();

        public int id { get; set; }
        public int playerID { get; set; }

        [ForeignKey("SportCenterID")]
        public int? spID { get; set; }
        public SportCenter SportCenterID { get; set; }

        [ForeignKey("cID")]
        public int? courtID { get; set; }
        public Court cID { get; set; }
        public string name { get; set; }
        public float Playerprice
        {
            get { return sCenter.price; }
            set { value = Playerprice; }
        }
        public string phone { get; set; }
        public DateTime timeSlot { get; set; }

    }

    public class SportCenter
    {
        Court court = new Court();
        public int id { get; set; }
        public string name { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int courtCount
        {
            get { return court.count; }
            set { value = courtCount; }
        }
        public string phone { get; set; }
        public float price { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string zip { get; set; }

    }
    public class Court
    {
        public int id { get; set; }

        [ForeignKey("SportCenterID")]
        public int? spID { get; set; }
        public SportCenter SportCenterID { get; set; }
        public bool availability { get; set; }
        public int count { get; set; }

    }
    public class Owner
    {
        Court court = new Court();
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ContextClass : DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> options) : base(options)
        {

        }

        public DbSet<Booking> bookingSet { get; set; }
        public DbSet<Court> courtSet { get; set; }
        public DbSet<Owner> ownerSet { get; set; }
        public DbSet<SportCenter> sportCenterSet { get; set; }
    }
}

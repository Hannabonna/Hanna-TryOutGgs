using System.Collections.Generic;
using System;

namespace TryOut01.Model
{
    // public enum Status{
    //     sending = 2,
    //     accepted = 1
    // }

    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public int DriverId { get; set; }
        public List<Oder_Detail> Oder_Details { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class Oder_Detail
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
    }
}
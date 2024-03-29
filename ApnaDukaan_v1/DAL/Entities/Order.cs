﻿using ApnaDukaan_v1.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApnaDukaan_v1.DAL.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public double TotalAmount { get; set; }
        public int AddressId { get; set; }
        public DateTime CreatedAt { get; set; }

        [EnumDataType(typeof(OrderStatusEnum))]
        public OrderStatusEnum OrderStatus { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

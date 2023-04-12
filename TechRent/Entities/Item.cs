﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechRent.Entities
{
    public class Item
    {
        public Guid Id { get; }
        public string ItemName { get; }
        public string Category { get; }
        public bool Rent { get; }

        public Item(Guid id, string itemName, string category, bool rent)
        {
            Id = id;
            ItemName = itemName;
            Category = category;
            Rent = rent;
        }
    }
}

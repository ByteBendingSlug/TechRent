using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechRent.Shared.DTOs
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public string? ItemName { get; set; }
        public string? Kategorie { get; set; }
        public bool Ausleihen { get; set; }
    }
}

using System;

namespace TechRent.Shared.DTOs
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public string? ItemName { get; set; }
        public string? Category { get; set; }
        public bool Rent { get; set; }
    }
}

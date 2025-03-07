using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBE.Models.Dtos;

public class ShopDto
{
    public Guid Id { get; set; }
    public string Domain { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
}

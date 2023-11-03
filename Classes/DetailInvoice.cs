using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Classes;

public class DetailInvoice
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public double Value { get; set; }
    public int IdInvoice { get; set; }
    public List<int> IdProduct { get; set; }
}

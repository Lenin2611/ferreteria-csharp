using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Classes;

public class Invoice
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public double Total { get; set; }
    public int IdClient { get; set; }
}

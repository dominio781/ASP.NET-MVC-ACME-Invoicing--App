﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

public class Invoice
{
    public int InvoiceID { get; set; }

    public int CustomerID { get; set; }
    public virtual Customer Customer { get; set; }

    public string Name { get; set; }

    public string Notes { get; set; }

    [DisplayName("Created")]
    public DateTime TimeStamp { get; set; }

    [DisplayName("Due Date")]
    public DateTime DueDate { get; set; }

    public bool Paid { get; set; }

    public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }

    public decimal Total {
        get {
            if (InvoiceDetails == null)
                return 0;

            return InvoiceDetails.Sum(i => i.Total);
        }
    }

    public decimal TotalWithVAT
    {
        get
        {
            if (InvoiceDetails == null)
                return 0;

            return InvoiceDetails.Sum(i => i.TotalPlusVAT);
        }
    }
}
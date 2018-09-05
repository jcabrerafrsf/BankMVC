using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace DataLayer.Entities
{
    public enum MovementType : int
    {

        [Display(Name = "Transferencia")]
        TRANSFER = 1,

        [Display(Name = "Depósito")]
        DEPOSIT = 2,

        [Display(Name = "Extracción")]
        EXTRACTION = 3

    }
}

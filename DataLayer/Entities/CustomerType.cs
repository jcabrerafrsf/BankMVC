using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace DataLayer.Entities
{
    public enum CustomerType : int
    {

        [Display(Name = "Persona Física")]
        NATURAL_PERSON = 1,

        [Display(Name = "Persona Jurídica")]
        LEGAL_PERSON = 2

    }
}

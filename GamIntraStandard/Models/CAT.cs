//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GamIntraStandard.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAT
    {
        public string CODI_CAT { get; set; }
        public string DES { get; set; }
        public decimal HORES_ANY { get; set; }
        public decimal IMP_SALARI { get; set; }
        public decimal IMP_PLUS_SALARI { get; set; }
        public decimal IMP_NOCTURNITAT { get; set; }
        public decimal IMP_EXTRES { get; set; }
        public Nullable<System.DateTime> DATA_INICI { get; set; }
        public Nullable<System.DateTime> DATA_FINAL { get; set; }
        public decimal PREU_HORA_PRESENCIA { get; set; }
        public decimal PREU_HORA_DESCANS { get; set; }
    }
}
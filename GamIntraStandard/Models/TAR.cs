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
    
    public partial class TAR
    {
        public string CODI_TAR { get; set; }
        public string CODI_TVH { get; set; }
        public string CODI_TFC { get; set; }
        public string DES { get; set; }
        public Nullable<System.DateTime> DATA_INICI_TAR { get; set; }
        public Nullable<System.DateTime> DATA_FINAL_TAR { get; set; }
        public decimal HORA_INICI_NIT { get; set; }
        public decimal HORA_FINAL_NIT { get; set; }
        public decimal PREU_KM { get; set; }
        public decimal PREU_ESPERA { get; set; }
        public decimal PREU_URBA_A { get; set; }
        public decimal PREU_URBA_B { get; set; }
        public decimal PREU_SORTIDA { get; set; }
        public decimal PREU_FESTIU { get; set; }
        public decimal PREU_NIT { get; set; }
        public decimal PREU_METGE { get; set; }
        public decimal PREU_INFERMERA { get; set; }
        public decimal PREU_HORA { get; set; }
        public string CODI_ART { get; set; }
        public decimal TANT_X100_NIT_FESTIU { get; set; }
        public decimal TANT_X100_IVA { get; set; }
        public decimal PREU_OXIGEN { get; set; }
        public decimal PREU_AERO { get; set; }
        public decimal DISSABTE_LABORAL_SI_NO { get; set; }
        public decimal NIT_FESTIU_SI_NO { get; set; }
        public decimal PREU_AJUDANT { get; set; }
        public string DES_ART { get; set; }
        public decimal MULTIPLICAR_KM_PER { get; set; }
        public string CODI_EMP { get; set; }
    }
}
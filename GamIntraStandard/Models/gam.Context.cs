﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gamEntities1 : DbContext
    {
        public gamEntities1()
            : base("name=gamEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AGE> AGE { get; set; }
        public DbSet<AGR> AGR { get; set; }
        public DbSet<ALC> ALC { get; set; }
        public DbSet<ALC_LIN> ALC_LIN { get; set; }
        public DbSet<ALP> ALP { get; set; }
        public DbSet<ALP_LIN> ALP_LIN { get; set; }
        public DbSet<ANU> ANU { get; set; }
        public DbSet<ATR> ATR { get; set; }
        public DbSet<ATU> ATU { get; set; }
        public DbSet<AUT> AUT { get; set; }
        public DbSet<AUT_LIN> AUT_LIN { get; set; }
        public DbSet<AVI> AVI { get; set; }
        public DbSet<BAN> BAN { get; set; }
        public DbSet<BAS> BAS { get; set; }
        public DbSet<CAA> CAA { get; set; }
        public DbSet<CAI> CAI { get; set; }
        public DbSet<CAI_HIS> CAI_HIS { get; set; }
        public DbSet<CAL> CAL { get; set; }
        public DbSet<CAP> CAP { get; set; }
        public DbSet<CAT> CAT { get; set; }
        public DbSet<CAT_SAL> CAT_SAL { get; set; }
        public DbSet<CCO> CCO { get; set; }
        public DbSet<CFG> CFG { get; set; }
        public DbSet<CHK> CHK { get; set; }
        public DbSet<CHK_DES> CHK_DES { get; set; }
        public DbSet<CLA> CLA { get; set; }
        public DbSet<COC> COC { get; set; }
        public DbSet<COC_LIN> COC_LIN { get; set; }
        public DbSet<COM> COM { get; set; }
        public DbSet<COP> COP { get; set; }
        public DbSet<COP_LIN> COP_LIN { get; set; }
        public DbSet<CPT> CPT { get; set; }
        public DbSet<DAC> DAC { get; set; }
        public DbSet<DAC_HIS> DAC_HIS { get; set; }
        public DbSet<DAT_ATU> DAT_ATU { get; set; }
        public DbSet<DAT_BEN> DAT_BEN { get; set; }
        public DbSet<DAT_BUS> DAT_BUS { get; set; }
        public DbSet<DAT_DES> DAT_DES { get; set; }
        public DbSet<DAT_MIS> DAT_MIS { get; set; }
        public DbSet<DAT_SRV> DAT_SRV { get; set; }
        public DbSet<DAT_TOR> DAT_TOR { get; set; }
        public DbSet<DEP> DEP { get; set; }
        public DbSet<DES> DES { get; set; }
        public DbSet<DEV> DEV { get; set; }
        public DbSet<DIA> DIA { get; set; }
        public DbSet<DIG> DIG { get; set; }
        public DbSet<DIG_EXTERN> DIG_EXTERN { get; set; }
        public DbSet<DIR> DIR { get; set; }
        public DbSet<DIR_EXTERN> DIR_EXTERN { get; set; }
        public DbSet<DIS> DIS { get; set; }
        public DbSet<DIS_DOC> DIS_DOC { get; set; }
        public DbSet<DIS_HIS> DIS_HIS { get; set; }
        public DbSet<DPA> DPA { get; set; }
        public DbSet<DST> DST { get; set; }
        public DbSet<ECO> ECO { get; set; }
        public DbSet<EMP> EMP { get; set; }
        public DbSet<EQU> EQU { get; set; }
        public DbSet<ESP> ESP { get; set; }
        public DbSet<EXT> EXT { get; set; }
        public DbSet<FAM> FAM { get; set; }
        public DbSet<FAP> FAP { get; set; }
        public DbSet<FAP_LIN> FAP_LIN { get; set; }
        public DbSet<FAP_REC> FAP_REC { get; set; }
        public DbSet<FCT> FCT { get; set; }
        public DbSet<FCT_REC> FCT_REC { get; set; }
        public DbSet<FDI> FDI { get; set; }
        public DbSet<FEE> FEE { get; set; }
        public DbSet<FEE_PRE> FEE_PRE { get; set; }
        public DbSet<FEE_TRB> FEE_TRB { get; set; }
        public DbSet<FIS> FIS { get; set; }
        public DbSet<FOM> FOM { get; set; }
        public DbSet<FPA> FPA { get; set; }
        public DbSet<FTE> FTE { get; set; }
        public DbSet<GAM> GAM { get; set; }
        public DbSet<GRP> GRP { get; set; }
        public DbSet<HIS> HIS { get; set; }
        public DbSet<HIS_PRG> HIS_PRG { get; set; }
        public DbSet<hola> hola { get; set; }
        public DbSet<HOS> HOS { get; set; }
        public DbSet<INC> INC { get; set; }
        public DbSet<INF> INF { get; set; }
        public DbSet<INF_TRB> INF_TRB { get; set; }
        public DbSet<INT> INT { get; set; }
        public DbSet<LAS> LAS { get; set; }
        public DbSet<LLI_HIS> LLI_HIS { get; set; }
        public DbSet<LOG_SCS> LOG_SCS { get; set; }
        public DbSet<LOT> LOT { get; set; }
        public DbSet<LOT_HIS> LOT_HIS { get; set; }
        public DbSet<LPD> LPD { get; set; }
        public DbSet<MAG> MAG { get; set; }
        public DbSet<MAS> MAS { get; set; }
        public DbSet<MAT> MAT { get; set; }
        public DbSet<MAT_DOC> MAT_DOC { get; set; }
        public DbSet<MAT_MAG> MAT_MAG { get; set; }
        public DbSet<MET> MET { get; set; }
        public DbSet<MOT> MOT { get; set; }
        public DbSet<MUL> MUL { get; set; }
        public DbSet<MUL_DOC> MUL_DOC { get; set; }
        public DbSet<MUL_HIS> MUL_HIS { get; set; }
        public DbSet<MVH> MVH { get; set; }
        public DbSet<NOC> NOC { get; set; }
        public DbSet<NUHSA> NUHSA { get; set; }
        public DbSet<OTR> OTR { get; set; }
        public DbSet<OTR_LIN> OTR_LIN { get; set; }
        public DbSet<PAC> PAC { get; set; }
        public DbSet<PAC_DOC> PAC_DOC { get; set; }
        public DbSet<PAQ> PAQ { get; set; }
        public DbSet<PAR> PAR { get; set; }
        public DbSet<PAT> PAT { get; set; }
        public DbSet<PATH_SCANNER> PATH_SCANNER { get; set; }
        public DbSet<PDA> PDA { get; set; }
        public DbSet<PLA> PLA { get; set; }
        public DbSet<PLL> PLL { get; set; }
        public DbSet<PLL_MES> PLL_MES { get; set; }
        public DbSet<PLL_VHI> PLL_VHI { get; set; }
        public DbSet<POB> POB { get; set; }
        public DbSet<POB_CP> POB_CP { get; set; }
        public DbSet<POB_EXTERN> POB_EXTERN { get; set; }
        public DbSet<PON> PON { get; set; }
        public DbSet<PRC> PRC { get; set; }
        public DbSet<PRG> PRG { get; set; }
        public DbSet<PRG_DOC> PRG_DOC { get; set; }
        public DbSet<PRG_HIS> PRG_HIS { get; set; }
        public DbSet<PRG_INC> PRG_INC { get; set; }
        public DbSet<PRO> PRO { get; set; }
        public DbSet<PRO_HIS> PRO_HIS { get; set; }
        public DbSet<PRV> PRV { get; set; }
        public DbSet<QUA> QUA { get; set; }
        public DbSet<QUA_BIS> QUA_BIS { get; set; }
        public DbSet<QUA_INC> QUA_INC { get; set; }
        public DbSet<RCL> RCL { get; set; }
        public DbSet<RCL_DOC> RCL_DOC { get; set; }
        public DbSet<RCL_HIS> RCL_HIS { get; set; }
        public DbSet<RCU> RCU { get; set; }
        public DbSet<REC> REC { get; set; }
        public DbSet<REC_CP> REC_CP { get; set; }
        public DbSet<REG> REG { get; set; }
        public DbSet<REG_DIA> REG_DIA { get; set; }
        public DbSet<REG_MAG> REG_MAG { get; set; }
        public DbSet<REV> REV { get; set; }
        public DbSet<RUT> RUT { get; set; }
        public DbSet<RUT_CP> RUT_CP { get; set; }
        public DbSet<RUT_OBS> RUT_OBS { get; set; }
        public DbSet<SCC> SCC { get; set; }
        public DbSet<SCS> SCS { get; set; }
        public DbSet<SEC> SEC { get; set; }
        public DbSet<SIG> SIG { get; set; }
        public DbSet<SIN> SIN { get; set; }
        public DbSet<SMS> SMS { get; set; }
        public DbSet<SQL> SQL { get; set; }
        public DbSet<SRV> SRV { get; set; }
        public DbSet<SRV_ASS> SRV_ASS { get; set; }
        public DbSet<SRV_DOC> SRV_DOC { get; set; }
        public DbSet<SRV_GPS> SRV_GPS { get; set; }
        public DbSet<SRV_INC> SRV_INC { get; set; }
        public DbSet<SRV_OBS> SRV_OBS { get; set; }
        public DbSet<SUA> SUA { get; set; }
        public DbSet<SYS_CON> SYS_CON { get; set; }
        public DbSet<SYS_LLI> SYS_LLI { get; set; }
        public DbSet<SYS_MEN> SYS_MEN { get; set; }
        public DbSet<SYS_TER> SYS_TER { get; set; }
        public DbSet<SYS_TRA> SYS_TRA { get; set; }
        public DbSet<TAR> TAR { get; set; }
        public DbSet<TAR_DST> TAR_DST { get; set; }
        public DbSet<TEL_HIS> TEL_HIS { get; set; }
        public DbSet<TFC> TFC { get; set; }
        public DbSet<TJO> TJO { get; set; }
        public DbSet<TLL> TLL { get; set; }
        public DbSet<TLO> TLO { get; set; }
        public DbSet<TMA> TMA { get; set; }
        public DbSet<TOR> TOR { get; set; }
        public DbSet<TOT> TOT { get; set; }
        public DbSet<TPR> TPR { get; set; }
        public DbSet<TRA> TRA { get; set; }
        public DbSet<TRA_EXTERN> TRA_EXTERN { get; set; }
        public DbSet<TRB> TRB { get; set; }
        public DbSet<TRB_ATR> TRB_ATR { get; set; }
        public DbSet<TRB_CTR> TRB_CTR { get; set; }
        public DbSet<TRB_DOC> TRB_DOC { get; set; }
        public DbSet<TRB_FOR> TRB_FOR { get; set; }
        public DbSet<TRB_HIS> TRB_HIS { get; set; }
        public DbSet<TRB_HUE> TRB_HUE { get; set; }
        public DbSet<TRB_INC> TRB_INC { get; set; }
        public DbSet<TRB_PLL> TRB_PLL { get; set; }
        public DbSet<TRB_VAC> TRB_VAC { get; set; }
        public DbSet<TRB_VES> TRB_VES { get; set; }
        public DbSet<TRM> TRM { get; set; }
        public DbSet<TSNUX> TSNUX { get; set; }
        public DbSet<TVH> TVH { get; set; }
        public DbSet<UP> UP { get; set; }
        public DbSet<UP_ESP> UP_ESP { get; set; }
        public DbSet<USU> USU { get; set; }
        public DbSet<USU_DEF> USU_DEF { get; set; }
        public DbSet<USU_EMP> USU_EMP { get; set; }
        public DbSet<USU_EXE> USU_EXE { get; set; }
        public DbSet<USU_FIL> USU_FIL { get; set; }
        public DbSet<USU_LLI> USU_LLI { get; set; }
        public DbSet<USU_POS> USU_POS { get; set; }
        public DbSet<USU_TAU> USU_TAU { get; set; }
        public DbSet<VHI> VHI { get; set; }
        public DbSet<VHI_CHK> VHI_CHK { get; set; }
        public DbSet<VHI_DOC> VHI_DOC { get; set; }
        public DbSet<VHI_GPS> VHI_GPS { get; set; }
        public DbSet<VHI_HIS> VHI_HIS { get; set; }
        public DbSet<VHI_INC> VHI_INC { get; set; }
        public DbSet<VHI_REV> VHI_REV { get; set; }
        public DbSet<VHI_SIN> VHI_SIN { get; set; }
        public DbSet<VHI_SIN_DOC> VHI_SIN_DOC { get; set; }
        public DbSet<VHI_SIN_HIS> VHI_SIN_HIS { get; set; }
        public DbSet<VIP> VIP { get; set; }
        public DbSet<VIP_HIS> VIP_HIS { get; set; }
        public DbSet<WEB_HIS> WEB_HIS { get; set; }
        public DbSet<ZON> ZON { get; set; }
        public DbSet<DAT> DAT { get; set; }
        public DbSet<DAT_APA> DAT_APA { get; set; }
        public DbSet<DEL_HIS> DEL_HIS { get; set; }
        public DbSet<MOD_FCT> MOD_FCT { get; set; }
        public DbSet<MOD_PAC> MOD_PAC { get; set; }
        public DbSet<MOD_PRG> MOD_PRG { get; set; }
        public DbSet<MOD_SRV> MOD_SRV { get; set; }
        public DbSet<MOD_TRB> MOD_TRB { get; set; }
        public DbSet<MOD_VHI> MOD_VHI { get; set; }
        public DbSet<TCO> TCO { get; set; }
        public DbSet<USU_HIS> USU_HIS { get; set; }
        public DbSet<USU_MEN> USU_MEN { get; set; }
        public DbSet<USU_PIC> USU_PIC { get; set; }
    }
}

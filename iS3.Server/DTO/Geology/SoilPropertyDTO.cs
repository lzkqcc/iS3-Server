using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS3.Geology;

namespace iS3.Server.DTO.Geology
{
    public class StratumSectionDTO : DGObjectDTO
    {
        public double? StartMileage { get; set; }
        public double? EndMileage { get; set; }

        public StratumSectionDTO() { }
        public StratumSectionDTO(StratumSection ss)
        {
            StartMileage = ss.StartMileage;
            EndMileage = ss.EndMileage;
        }
    }

    public class SoilDynamicPropertyDTO
    {
        public double? G0 { get; set; }
        public double? ar { get; set; }
        public double? br { get; set; }

        public SoilDynamicPropertyDTO() { }
        public SoilDynamicPropertyDTO(SoilDynamicProperty sdp)
        {
            G0 = sdp.G0;
            ar = sdp.ar;
            br = sdp.br;
        }
    }

    public class SoilStaticPropertyDTO
    {
        public double? w { get; set; }
        public double? gama { get; set; }
        public double? c { get; set; }
        public double? fai { get; set; }
        public double? cuu { get; set; }
        public double? faiuu { get; set; }
        public double? Cs { get; set; }
        public double? qu { get; set; }
        public double? K0 { get; set; }
        public double? Kv { get; set; }
        public double? Kh { get; set; }
        public double? e { get; set; }
        public double? av { get; set; }
        public double? Cu { get; set; }

        public double? G { get; set; }
        public double? Sr { get; set; }
        public double? ccq { get; set; }
        public double? faicq { get; set; }
        public double? c_s { get; set; }
        public double? fais { get; set; }
        public double? a01_02 { get; set; }
        public double? Es01_02 { get; set; }
        public double? c_u { get; set; }
        public double? faiu { get; set; }
        public double? ccu { get; set; }
        public double? faicu { get; set; }
        public double? cprime { get; set; }
        public double? faiprime { get; set; }
        public double? E015_0025 { get; set; }
        public double? E02_0025 { get; set; }
        public double? E04_0025 { get; set; }

        public SoilStaticPropertyDTO() { }
        public SoilStaticPropertyDTO(SoilStaticProperty ssp)
        {
            w = ssp.w;
            gama = ssp.gama;
            c = ssp.c;
            fai = ssp.fai;
            cuu = ssp.cuu;
            faiuu = ssp.faiuu;
            Cs = ssp.Cs;
            qu = ssp.qu;
            K0 = ssp.K0;
            Kv = ssp.Kv;
            Kh = ssp.Kh;
            e = ssp.e;
            av = ssp.av;
            Cu = ssp.Cu;
            G = ssp.G;
            Sr = ssp.Sr;
            ccq = ssp.ccq;
            faicq = ssp.faicq;
            c_s = ssp.c_s;
            fais = ssp.fais;
            a01_02 = ssp.a01_02;
            Es01_02 = ssp.Es01_02;
            c_u = ssp.c_u;
            faiu = ssp.faiu;
            ccu = ssp.ccu;
            faicu = ssp.faicu;
            cprime = ssp.cprime;
            faiprime = ssp.faiprime;
            E015_0025 = ssp.E015_0025;
            E02_0025 = ssp.E02_0025;
            E04_0025 = ssp.E04_0025;
        }
    }
    
    public class SoilPropertyDTO : DGObjectDTO
    {
        public int StratumID { get; set; }
        public int? StratumSectionID { get; set; }
        public SoilStaticPropertyDTO StaticProp { get; set; }
        public SoilDynamicPropertyDTO DynamicProp { get; set; }

        public SoilPropertyDTO() { }
        public SoilPropertyDTO(SoilProperty sp)
        {
            StratumID = sp.StratumID;
            StratumSectionID = sp.StratumSectionID;
            StaticProp = new SoilStaticPropertyDTO(sp.StaticProp);
            DynamicProp = new SoilDynamicPropertyDTO(sp.DynamicProp);
        }
        public static List<SoilPropertyDTO> transferList(List<SoilProperty> sps)
        {
            List<SoilPropertyDTO> res = new List<SoilPropertyDTO>();
            foreach (SoilProperty sp in sps) res.Add(new SoilPropertyDTO(sp));
            return res;
        }
    }
}
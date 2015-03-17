using System;
using System.Collections.Generic;
using System.Linq;

namespace EnviaNomina
{
    public class Nomina
    {
        public string Nombre { get; set; }
        public string FechaPago { get; set; }
        public string FechaInicialPago { get; set; }
        public string FechaFinalPago { get; set; }
        public string NumDiasPagados { get; set; }
        public string Moneda { get; set; }
        public string Rate { get; set; }
        public string SucursalId { get; set; }
        public string Serie { get; set; }
        public string CondicionDePago { get; set; }
        public string MetodoDePago { get; set; }
        public string FormaDePago { get; set; }
        public string Decimales { get; set; }

        public List<Empleados> Empleados { get; set; }
    }
}

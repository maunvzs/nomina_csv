using System;
using System.Collections.Generic;
using System.Linq;

namespace EnviaNomina
{
    public class Empleados
    {
        public string Cantidad { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }
        public string ValorUnitario { get; set; }
        public string Subtotal { get; set; }
        public string Descuento { get; set; }
        public string MotivoDescuento { get; set; }
        public string ISR { get; set; }
        public string Total { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string Calle { get; set; }
        public string NumeroExt { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Puesto { get; set; }
        public string TipoContrato { get; set; }
        public string TipoJornada { get; set; }
        public string NumEmpleado { get; set; }
        public string NumSeguro{ get; set; }
        public string PeriodicidadPago { get; set; }
        public string SalarioBase { get; set; }
        public string SalarioDiario { get; set; }
        public string InicioRelacionLaboral { get; set; }
        public string Regimen { get; set; }
        public string RiesgoPuesto { get; set; }
        public string Departamento { get; set; }
        public string NumCuenta { get; set; }
        public string Email { get; set; }

        public List<Percepcion> Percepcion { get; set; }
        public List<Deduccion> Deduccion { get; set; }
    }
}

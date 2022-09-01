using et12.edu.ar.AGBD.Mapeadores;
using et12.edu.ar.AGBD.Ado;
using System;
using System.Data;
using System.Collections.Generic;
using RestoMVC.Core;
using RestoMVC.Core.AdoET12;


namespace RestoMVC.Core.AdoET12.Mapeadores
{
    public class MapRestaurante : Mapeador<Restaurante>
    {
        public MapRestaurante(AdoAGBD ado) : base(ado)
            => Tabla = "Restaurante";
        public override Restaurante ObjetoDesdeFila(DataRow fila)
        => new Restaurante()
        {
            Id = Convert.ToInt32(fila["id"]),
            Nombre = fila["nombre"].ToString(),
            Direccion = fila["direccion"].ToString(),
            Mail = fila["mail"].ToString(),
            Telefono = Convert.ToInt32(fila["telefono"]),
            Contrasenia = fila["contrasenia"].ToString()
        };
        public void AltaRestaurante(Restaurante restaurante)
            => EjecutarComandoCon("altaRestaurante", ConfigurarAltaRestaurante, restaurante);

        public void ConfigurarAltaRestaurante(Restaurante restaurante)
        {
            SetComandoSP("altaRestaurante");

            BP.CrearParametro("id")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                    .SetValor(restaurante.Id)
                    .AgregarParametro();

            BP.CrearParametro("nombre")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Nombre)
                    .AgregarParametro();
            
            BP.CrearParametro("direccion")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Direccion)
                    .AgregarParametro();

            BP.CrearParametro("mail")
                    .SetTipoVarchar(45)
                    .SetValor(restaurante.Mail)
                    .AgregarParametro();

            BP.CrearParametro("telefono")
                    .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                    .SetValor(restaurante.Telefono)
                    .AgregarParametro();

            BP.CrearParametro("contrasenia")
                    .SetTipoVarchar(64)
                    .SetValor(restaurante.Contrasenia)
                    .AgregarParametro();
        }

        public Restaurante RestaurantePorId(int Id)
        {
            SetComandoSP("RestaurantePorId");

            BP.CrearParametro("unId")
                .SetTipo(MySql.Data.MySqlClient.MySqlDbType.Int32)
                .SetValor(Id)
                .AgregarParametro();

            return ElementoDesdeSP();
        }
        public Restaurante restoPorPass(string Mail ,string Contrasenia)
        {
            SetComandoSP("restoPorPass");

            BP.CrearParametro("unMail")
                .SetTipoVarchar(45)
                .SetValor(Mail)
                .AgregarParametro();
            
            BP.CrearParametro("unaContrasenia")
                .SetTipoVarchar(64)
                .SetValor(Contrasenia)
                .AgregarParametro();

            return ElementoDesdeSP();

        }

        public List<Restaurante> ObtenerRestaurante() => ColeccionDesdeTabla();
    }

}
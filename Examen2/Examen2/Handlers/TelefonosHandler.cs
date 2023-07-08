using System;
using System.Collections.Generic;
using Examen2.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Examen2.Handlers
{
    public class TelefonosHandler
    {

        private SqlConnection conexion;
        private string rutaConexion;
        public TelefonosHandler()
        {
            var builder = WebApplication.CreateBuilder();
            rutaConexion =
            builder.Configuration.GetConnectionString("Examen2");
            conexion = new SqlConnection(rutaConexion);
            conexion = new SqlConnection(rutaConexion);
        }

        private DataTable CrearTablaConsulta(string consulta)
        {
            SqlCommand comandoParaConsulta = new SqlCommand(consulta,
            conexion);
            SqlDataAdapter adaptadorParaTabla = new
            SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();
            conexion.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            conexion.Close();
            return consultaFormatoTabla;
        }

        public List<TelefonoModelo> ObtenerTelefonos ()
        {
            List<TelefonoModelo> telefonos = new List<TelefonoModelo>();
            string consulta = "SELECT * FROM Telefonos";
            DataTable tablaResultado = CrearTablaConsulta(consulta);
            foreach (DataRow columna in tablaResultado.Rows)
            {
                telefonos.Add(new TelefonoModelo
                {
                    ID = Convert.ToInt32(columna["Id"]),
                    Marca = Convert.ToString(columna["Marca"]),
                    Modelo = Convert.ToString(columna["Modelo"]),
                    Color = Convert.ToString(columna["Color"]),
                    Cores = Convert.ToInt32(columna["Cores"]),
                    Android = Convert.ToInt32(columna["Android"]) == 1
                });
            }
            return telefonos;
        }

        public bool CrearTelefono(TelefonoModelo telefono)
        {
            var consulta = @"INSERT INTO [dbo].[Telefonos] ([Marca],[Modelo],[Color],[Cores],[Android]) VALUES(@Marca, @Modelo, @Color, @Cores, @Android)";
            var comandoParaConsulta = new SqlCommand(consulta, conexion);
            comandoParaConsulta.Parameters.AddWithValue("@Marca", telefono.Marca);
            comandoParaConsulta.Parameters.AddWithValue("@Modelo", telefono.Modelo);
            comandoParaConsulta.Parameters.AddWithValue("@Color", telefono.Color);
            comandoParaConsulta.Parameters.AddWithValue("@Cores", telefono.Cores);
            comandoParaConsulta.Parameters.AddWithValue("@Android", telefono.Android);

            conexion.Open();
            bool exito = comandoParaConsulta.ExecuteNonQuery() >= 1;
            conexion.Close();

            return exito;
        }


        public bool EditarTelefono(TelefonoModelo telefono)
        {
            var consulta = @"UPDATE [dbo].[Telefonos] SET
                    Marca = @Marca,
                    Modelo = @Modelo,
                    Color = @Color,
                    Cores = @Cores,
                    Android = @Android
                    WHERE ID=@ID";

            var cmdParaConsulta = new SqlCommand(consulta, conexion);
            cmdParaConsulta.Parameters.AddWithValue("@Marca", telefono.Marca);
            cmdParaConsulta.Parameters.AddWithValue("@Modelo", telefono.Modelo);
            cmdParaConsulta.Parameters.AddWithValue("@Color", telefono.Color);
            cmdParaConsulta.Parameters.AddWithValue("@Cores", telefono.Cores);
            cmdParaConsulta.Parameters.AddWithValue("@Android", telefono.Android);
            cmdParaConsulta.Parameters.AddWithValue("@ID", telefono.ID);

            conexion.Open();
            bool exito = cmdParaConsulta.ExecuteNonQuery() >= 1;
            conexion.Close();

            return exito;
        }
        

        public bool BorrarTelefono(TelefonoModelo telefono)
        {
            var consulta = @"DELETE [dbo].[Telefonos] WHERE ID=@ID";

            var cmdParaConsulta = new SqlCommand(consulta, conexion);
            cmdParaConsulta.Parameters.AddWithValue("@ID", telefono.ID);

            conexion.Open();
            bool exito = cmdParaConsulta.ExecuteNonQuery() >= 1;
            conexion.Close();

            return exito;
        }

    }



}

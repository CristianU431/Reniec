using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reniec
{
    public partial class frmCiudano : System.Web.UI.Page
    {
        //Acceder al servicio web
        srCiudadano1.wsCiudadanoSoapClient servicio = new srCiudadano1.wsCiudadanoSoapClient();

        //Metodo para listar 
        private void Listar()
        {
            gvCiudadano.DataSource = servicio.Listar().Tables[0];
            gvCiudadano.DataBind();
        } 

        protected void Page_Load(object sender, EventArgs e)
        {
            //Solo debe cargar la primera vez
            if (!Page.IsPostBack)
                Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            // Agregar un Ciudadano a la tabla DocIdentidad
            int DNI = int.Parse(txtDNI.Text.Trim());
            string Nombres = txtNombres.Text.Trim();
            string ApellidoPaterno = txtApPaterno.Text.Trim();
            string ApellidoMaterno = txtApMaterno.Text.Trim();
            string FechaNacimiento = txtFecNacimiento.Text.Trim();
            string Sexo = txtSexo.Text.Trim();
            string EstadoCivil = txtEstCivil.Text.Trim();
            string Direccion = txtDireccion.Text.Trim();
            bool bandera = servicio.Agregar(DNI, Nombres, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Sexo, EstadoCivil, Direccion);
            if (bandera)
            {
                Listar();
                Response.Write("<script>alert('Se agrego correctamente');</script>");
            }
            else
                Response.Write("Error: No se agrego region");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            // Eliminar un Ciudadano de la tabla DocIdentidad
            int DNI = int.Parse(txtDNI.Text.Trim());
            bool bandera = servicio.Eliminar(DNI);
            if (bandera)
            {
                Listar();
                Response.Write("<script>alert('Se Elimino correctamente');</script>");
            }
            else
                Response.Write("Error: No se pudo elimininar");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            // Actualizar un Ciudadano de la tabla DocIdentidad
            int DNI = int.Parse(txtDNI.Text.Trim());
            string Nombres = txtNombres.Text.Trim();
            string ApellidoPaterno = txtApPaterno.Text.Trim();
            string ApellidoMaterno = txtApMaterno.Text.Trim();
            string FechaNacimiento = txtFecNacimiento.Text.Trim();
            string Sexo = txtSexo.Text.Trim();
            string EstadoCivil = txtEstCivil.Text.Trim();
            string Direccion = txtDireccion.Text.Trim();
            bool bandera = servicio.Actualizar(DNI, Nombres, ApellidoPaterno, ApellidoMaterno, FechaNacimiento, Sexo, EstadoCivil, Direccion);
            if (bandera)
            {
                Listar();
                Response.Write("<script>alert('Se actualizo correctamente');</script>");
            }
            else
                Response.Write("Error: No se pudo actualizar");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Buscar una Ciudadano de la tabla DocIdentidad
            int DNI = int.Parse(txtDNI.Text.Trim());
            bool bandera = servicio.Buscar(DNI);
            if (bandera)
            {
                Listar();
                Response.Write("<script>alert('Se agrego correctamente');</script>");
            }
            else
                Response.Write("Error: No se agrego region");
        }
    }
}
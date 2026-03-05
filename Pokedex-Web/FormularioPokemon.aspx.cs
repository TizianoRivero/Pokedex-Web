using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokedex_Web
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    List<Elemento> lista = negocio.listar();

                    ddlTipo.DataSource = lista;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlDebilidad.DataSource = lista;
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    //List<Pokemon> lista = negocio.listar(id);
                    //Pokemon seleccionado = lista[0];
                    Pokemon seleccionado = (negocio.listar(id))[0];

                    Session.Add("pokeSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtNombre.Text = seleccionado.NOMBRE;
                    txtDescripcion.Text = seleccionado.DESCRIPCION;
                    txtImagenUrl.Text = seleccionado.URLIMAGEN;
                    txtNumero.Text = seleccionado.NUMERO.ToString();

                    ddlTipo.SelectedValue = seleccionado.TIPO.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.DEBILIDAD.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);

                    if (!seleccionado.ACTIVO)
                        btnInactivar.Text = "Reactivar";
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                //redireccion a error
            }
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                nuevo.NUMERO = int.Parse(txtNumero.Text);
                nuevo.NOMBRE = txtNombre.Text;
                nuevo.DESCRIPCION = txtDescripcion.Text;
                nuevo.URLIMAGEN = txtImagenUrl.Text;

                nuevo.TIPO = new Elemento();
                nuevo.TIPO.Id = int.Parse(ddlTipo.SelectedValue);
                nuevo.DEBILIDAD = new Elemento();
                nuevo.DEBILIDAD.Id = int.Parse(ddlDebilidad.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.ID = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                }    
                else
                    negocio.AgregarConSP(nuevo);
                
                Response.Redirect("ListarPokemon.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error",ex);
                throw;
                //redireccion a error
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.Eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListarPokemon.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();

                Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];

                negocio.EliminarLogico(seleccionado.ID, !seleccionado.ACTIVO);
                Response.Redirect("ListarPokemon.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}
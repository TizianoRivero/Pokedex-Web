using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Pokedex_Web
{
    public partial class ListarPokemon : System.Web.UI.Page
    {
        public bool FiltroAvanzado {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Session.Add("ListarPokemon", negocio.ListarConSP());
                dgvPokemons.DataSource = Session["ListarPokemon"];
                dgvPokemons.DataBind();
            }
            
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id=" + Id);
        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["ListarPokemon"];
            List<Pokemon> listaFiltrada = lista.FindAll(x => x.NOMBRE.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvPokemons.DataSource= listaFiltrada;
            dgvPokemons.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampos.SelectedItem.ToString() == "Número")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza Con");
                ddlCriterio.Items.Add("Termina Con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvPokemons.DataSource = negocio.filtrar
                    (ddlCampos.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtAvanzado.Text, 
                    ddlEstado.SelectedItem.ToString());

                dgvPokemons.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}
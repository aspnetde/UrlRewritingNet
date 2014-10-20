using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Globalization;

public partial class _Default : Page
{

    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    /// aweinert
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("<hr><b>page_load start</b><br>");
        foreach (string param in Request.QueryString)
            Response.Write(param + "=" + Request.QueryString[param] + "<br />");
        Response.Write("<br><b>page_load end</b><hr>");
    }

    /// <summary>
    /// Legt <see cref="P:System.Web.UI.Page.Culture"></see> und <see cref="P:System.Web.UI.Page.UICulture"></see> für den aktuellen Thread der Seite fest.
    /// </summary>
    /// aweinert
    protected override void InitializeCulture()
    {
        string ui = Request.QueryString["language"];

        // Simple Language Setting, only for Demo.
        if (string.IsNullOrEmpty(ui))
            ui = "de";
        string culture = ui == "en" ? "en-us" : ui + "-" + ui;
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(ui);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
        base.InitializeCulture();

   }

    /// <summary>
    /// Handles the Click event of the Button1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
    /// aweinert
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.Text = TextBox1.Text;
    }

    /// <summary>
    /// Löst das <see cref="E:System.Web.UI.Control.PreRender"></see>-Ereignis aus.
    /// </summary>
    /// <param name="e">Ein <see cref="T:System.EventArgs"></see>-Objekt, das die Ereignisdaten enthält.</param>
    /// aweinert
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
    }

}

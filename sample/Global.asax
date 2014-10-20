<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code, der beim Beenden der Anwendung ausgeführt wird.

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code, der bei einem nicht behandelten Fehler ausgeführt wird.

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code, der beim Starten einer neuen Sitzung ausgeführt wird.

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code, der am Ende einer Sitzung ausgeführt wird. 
        // Hinweis: Das Session_End-Ereignis wird nur ausgelöst, wenn der sessionstate-Modus
        // in der Datei "Web.config" auf InProc festgelegt wird. Wenn der Sitzungsmodus auf StateServer 
        // oder SQLServer festgelegt wird, wird das Ereignis nicht ausgelöst.

    }
       
</script>

<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="estadistica.aspx.cs" Inherits="Laboratorio.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="HF_proyecto" runat="server" />
    <asp:HiddenField ID="HF_Protocolo" runat="server" />
    <asp:HiddenField ID="HF_Actividad" runat="server" />
    <h2>Usted esta en la Pagina de Estadistica / Consultas</h2>
    <br />
    <br />

    <asp:MultiView ID="MultiView" runat="server">
        <asp:View ID="ViewProyecto" runat="server">
            <div style="display: flex; justify-content: space-between">
                <h2>
                    <asp:Label runat="server" Text="Proyectos"></asp:Label></h2>
                
            </div>
            <asp:GridView ID="GV_Proyecto" runat="server"
                Width="100%"
                AutoGenerateColumns="false"
                ShowHeader="true"
                BorderStyle="Ridge"
                CaptionAlign="Bottom"
                RowStyle-VerticalAlign="Middle"
                RowStyle-HorizontalAlign="Center"
                HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center"
                HeaderStyle-VerticalAlign="Middle"
                OnRowCommand="GV_Proyecto_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Id Proyecto">
                        <ItemTemplate>
                            <%# Eval("Id")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <%# Eval("Nombre")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Fin">
                        <ItemTemplate>
                            <%# Eval("FechaFin")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observaciones">
                        <ItemTemplate>
                            <%# Eval("ObservacionesProyecto")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <%# Eval("Estado")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Responsable">
                        <ItemTemplate>
                            <%# Eval("Responsable")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Puntaje">
                        <ItemTemplate>
                            <%# Eval("puntaje")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PROTOCOLOS">
                        <ItemTemplate>
                            <asp:Button ID="BTN_proyecto"
                                Text="VER"
                                runat="server"
                                CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="ViewProtocolos" runat="server">
            <div style="display: flex; justify-content: space-between">
                <h2>
                    <asp:Label runat="server" Text="Protocolos"></asp:Label></h2>
                <asp:Button ID="backproyecto" runat="server" Text="Volver a Proyectos" OnClick="backproyecto_Click" />
            </div>
            <asp:Label ID="LBL_IDPROYECTO" runat="server"></asp:Label>
            <asp:GridView ID="GV_Protocolo"
                runat="server"
                Width="100%"
                AutoGenerateColumns="false"
                ShowHeader="true"
                BorderStyle="Ridge"
                CaptionAlign="Bottom"
                RowStyle-VerticalAlign="Middle"
                RowStyle-HorizontalAlign="Center"
                HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center"
                HeaderStyle-VerticalAlign="Middle"
                OnRowCommand="GV_Protocolo_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Id Protocolo">
                        <ItemTemplate>
                            <%# Eval("IdProtocolo")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <%# Eval("Nombre")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Inicio">
                        <ItemTemplate>
                            <%# Eval("FechaInicio")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Fin">
                        <ItemTemplate>
                            <%# Eval("FechaFin")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Puntaje">
                        <ItemTemplate>
                            <%# Eval("PuntajeProtocolo")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <%# Eval("Estado")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Observaciones">
                        <ItemTemplate>
                            <%# Eval("ObservacionesProtocolo")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ACTIVIDADES">
                        <ItemTemplate>
                            <asp:Button ID="LINK_IR_ACTIVIDADES"
                                runat="server"
                                Text="VER"
                                CommandArgument='<%# Eval("IdProtocolo")%>'></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
        <asp:View ID="ViewActividades" runat="server">
            <div style="display: flex; justify-content: space-between">
                <h2>
                    <asp:Label runat="server" Text="Actividades"></asp:Label></h2>
                <asp:Button ID="backprotocolo" runat="server" Text="Volver a Protocolos" OnClick="backprotocolo_Click" />
            </div>
            <asp:GridView ID="GV_ACTIVIDAD"
                runat="server"
                Width="100%"
                AutoGenerateColumns="false"
                ShowHeader="true"
                BorderStyle="Ridge"
                CaptionAlign="Bottom"
                RowStyle-VerticalAlign="Middle"
                RowStyle-HorizontalAlign="Center"
                HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center"
                HeaderStyle-VerticalAlign="Middle">
              
                <Columns>
                    <asp:TemplateField HeaderText="Id Actividad">
                        <ItemTemplate>
                            <%# Eval("id")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion">
                        <ItemTemplate>
                            <%# Eval("Descripcion")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Finalizada">
                        <ItemTemplate>
                            <%# Eval("Finalizada").ToString()== "True" ? "SI":"NO" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Puntaje">
                        <ItemTemplate>
                            <%# Eval("Puntaje")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>

</asp:Content>

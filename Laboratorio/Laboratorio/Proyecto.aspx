<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proyecto.aspx.cs" Inherits="Laboratorio.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Button runat="server"
        Text="Nuevo Proyecto"
        ID="BTN_NUEVO_PROYECTO"
        CssClass="btn btn-block btn-success btn-lg"
        OnClick="BTN_NUEVO_PROYECTO_Click" />

    <asp:Panel CssClass="jumbotron" ID="PNL_AGREGAR_PROYECTO" runat="server" Visible="false">
        <asp:ImageButton ID="BTN_CANCELAR_NUEVO_PROYECTO"
            ImageUrl="fonts\Iconos\icono_x.svg"
            runat="server"
            ImageAlign="right"
            AlternateText="Cancelar"
            OnClick="BTN_CANCELAR_NUEVO_PROYECTO_Click" />

        <div class="row">
            <div class="col-md-6 ">
                <asp:Label ID="LBL_NOMBREPROYECTO" runat="server" Text="Ingrese Nombre del Proyecto"></asp:Label>
                <br />
                <asp:TextBox ID="TXT_NOMBREPROYECTO" CssClass="form-control"
                    runat="server"
                    TextMode="SingleLine"
                    placeholder="Ingrese el nombre del Proyecto"
                    Width="266px"></asp:TextBox>
                <br />

                <asp:Label ID="LBL_OBSERVACIONESPROYECTO" runat="server" Text="Ingrese Observaciones del Proyecto"></asp:Label>
                <br />
                <asp:TextBox ID="TXT_OBSERVACIONES_PROYECTO"
                    placeholder="Aca poner observaciones"
                    runat="server"
                    Width="266px"
                    TextMode="MultiLine"> </asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LBL_RESPONSABLEPROYECTO" runat="server" Text="Seleccione Responsable del Proyecto"></asp:Label>
                <br />
                <asp:DropDownList ID="DDL_RESPONSABLEPROYECTO" runat="server" AutoPostBack="true"></asp:DropDownList>
                <br />
                <br />
            </div>

            <div class="col-md-6">

                <asp:Label ID="LBL_TituloCalendar" runat="server" Text="Ingrese Fecha de Finalizacion del Proyecto"></asp:Label>
                <asp:Calendar ID="FECHAFIN_PROYECTO" runat="server"></asp:Calendar>
                <br />
            </div>
        </div>
        <div style="text-align: center">
            <asp:Button ID="BTN_AGREGAR_PROYECTO"
                runat="server"
                CssClass="btn btn-primary btn-lg"
                OnClick="BTN_AGREGAR_PROYECTO_Click"
                HorizontalAlign="center" />
        </div>
    </asp:Panel>
    <br />
    <br />
        
    <div class="row">
        <div class="col-md-12">
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
                    <asp:TemplateField HeaderText="Puntaje">
                        <ItemTemplate>
                            <%# Eval("puntaje")%>
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
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:LinkButton ID="BTN_EDITAR_PROYECTO" runat="server" Text="EDITAR"
                                CssClass="btn btn-warning"
                                CommandName="EDITAR"
                                CommandArgument='<%# Eval("Id") %>' 
                                Visible='<%# this.proyectofinalizado(int.Parse((Eval("Id").ToString()))) %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="BTN_ELIMINAR_PROYECTO" runat="server"
                                CssClass="btn btn-danger"
                                CommandName="ELIMINAR"
                                Text="ELIMINAR"
                                CommandArgument='<%# Eval("Id") %>'
                                Visible='<%# this.proyectofinalizado(int.Parse((Eval("Id").ToString()))) %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Finalizar">
                        <ItemTemplate>
                            <asp:LinkButton ID="BTN_FINALIZAR_PROYECTO" runat="server"
                                CssClass="btn btn-primary "
                                CommandName="FINALIZAR"
                                Text="FINALIZAR"
                                CommandArgument='<%# Eval("Id") %>' 
                                Visible='<%# this.proyectofinalizado(int.Parse((Eval("Id").ToString()))) %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Rechazar" Visible="true">
                        <ItemTemplate>
                            <asp:LinkButton ID="BTN_RECHAZAR_PROYECTO" runat="server"
                                CssClass="btn btn-dark"
                                CommandName="RECHAZAR"
                                Text="RECHAZAR"                         
                                CommandArgument='<%# Eval("Id") %>' Visible='<%# this.ROLADMINISTRADOR() %>'> 
                              </asp:LinkButton>  
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PROTOCOLOS">
                        <ItemTemplate>
                            <asp:HyperLink ID="LINK_IR_PROTOCOLOS" runat="server"
                                NavigateUrl='<%# string.Format("~/Protocolos.aspx?id={0}", Eval("Id")) %>'
                                PostBackUrl="~/Proyecto.aspx">VER</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="HF_EDITARPROYECTO" />
    <asp:HiddenField runat="server" ID="HF_IDPROYECTO" />
    <asp:HiddenField runat="server" ID="HF_RECHAZARPROYECTO" />
    <div class="modal fade" id="MODAL_ELIMINARPROYECTO"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalCenterTitle"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Eliminar</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Desea Eliminar el Proyecto?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="BTN_ACEPTARELIMINARPROYECTO" 
                        OnClick="BTN_ACEPTARELIMINARPROYECTO_Click" 
                        runat="server" class="btn btn-primary" Text="Aceptar"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="MODAL_RECHAZARPROYECTO"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalCenterTitle"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title"> LABORATORIO TONASBEACH</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Desea RECHAZAR el Proyecto?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="BTN_ACEPTARRECHAZARPROYECTO" 
                        OnClick="BTN_ACEPTARRECHAZARPROYECTO_Click" runat="server" 
                        class="btn btn-primary" Text="Aceptar"></asp:Button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

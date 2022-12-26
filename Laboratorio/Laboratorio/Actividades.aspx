<%@ Page Title="" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actividades.aspx.cs" 
    Inherits="Laboratorio.Actividades" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:HiddenField ID="HF_IDPROTOCOLO" runat="server" />
    <asp:HiddenField ID="HF_IDPROYECTO" runat="server" />
    
   
    <asp:Button runat="server"
        Text="Nueva Actividad"
        ID="BTN_NUEVA_ACTIVIDAD"
        CssClass="btn btn-block btn-success btn-lg"
        OnClick="BTN_NUEVA_ACTIVIDAD_Click" />

    <asp:Panel CssClass="jumbotron" ID="PNL_AGREGAR_ACTIVIDAD" runat="server" Visible="false">
        <asp:ImageButton ID="BTN_CANCELAR_NUEVA_ACTIVIDAD"
            ImageUrl="fonts\Iconos\icono_x.svg"
            runat="server"
            ImageAlign="right"
            AlternateText="Cancelar"
            OnClick="BTN_CANCELAR_NUEVA_ACTIVIDAD_Click" />
        <div class="row">
            <div class="col-md-12 ">
                <asp:TextBox ID="TXT_DESCRIPCIONACTIVIDAD" CssClass="form-control"
                    runat="server"
                    TextMode="SingleLine"
                    placeholder="Ingrese el nombre de la Activdad"
                    Width="266px"></asp:TextBox>
                <br />

                <asp:Label ID="LBL_FINALIZADA" runat="server" 
                    Text="Tilde si la actividad esta finalizada" Visible="false"></asp:Label>
                <asp:CheckBox ID="CHK_ACTIVIDAD_FINALIZADA" AutoPostBack="true" runat="server"
                    OnCheckedChanged="CHK_ACTIVIDAD_FINALIZADA_CheckedChanged" Visible="false" />
                <asp:TextBox ID="TXT_PUNTAJE_ACTIVIDAD" AutoPostBack="false" runat="server" 
                    placeholder="ingrese puntaje" Visible="false"></asp:TextBox>
                <br />
                <br />
            </div>

        </div>
        <div style="text-align: center">
            <asp:Button ID="BTN_AGREGAR_ACTIVIDAD"
                runat="server"
                Text="Agregar Actividad"
                CssClass="btn btn-primary btn-lg"
                OnClick="BTN_AGREGAR_ACTIVIDAD_Click"
                HorizontalAlign="center" />
        </div>
    </asp:Panel>
    <br />

    <div style="display:flex;flex-direction:row; justify-content:space-between">
    <asp:Label ID="LBL_NUMEROPROTOCOLO" runat="server"></asp:Label>
    <asp:Button runat="server" 
            Text="Volver a Protocolos" ID="btn_back_protocolo"
            OnClick="btn_back_protocolo_Click" />
    </div>
    <div class="row">
        <div class="col-md-12">
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
                HeaderStyle-VerticalAlign="Middle"
                OnRowCommand="GV_ACTIVIDAD_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Id Actividad">
                        <ItemTemplate>
                            <%# Eval("Id")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripcion">
                        <ItemTemplate>
                            <%# Eval("Descripcion")%>
                        </ItemTemplate>
                    </asp:TemplateField>                 
                    <asp:TemplateField HeaderText="Puntaje">
                        <ItemTemplate>
                            <%# Eval("Puntaje")%>
                        </ItemTemplate>
                    </asp:TemplateField>  <asp:TemplateField HeaderText="Finalizada">
                        <ItemTemplate>
                            <%# Eval("Finalizada").ToString()== "True" ? "SI":"NO" %>
                        </ItemTemplate>  
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:LinkButton ID="BTN_EDITAR_ACTIVIDAD" runat="server"
                                Text="EDITAR o FINALIZAR"
                                CssClass="btn btn-warning"
                                CommandName="EDITAR"
                                CommandArgument='<%# Eval("Id") %>' Visible='<%# this.actividadfinalizada(int.Parse((Eval("Id").ToString()))) %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BORRAR">
                        <ItemTemplate>
                            <asp:LinkButton ID="BTN_ELIMINAR_ACTIVIDAD" runat="server"
                                Text="ELIMINAR"
                                CssClass="btn btn-danger"
                                CommandName="ELIMINAR"
                                CommandArgument='<%# Eval("Id") %>' Visible='<%# this.actividadfinalizada(int.Parse((Eval("Id").ToString()))) %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <br />
    <div style="display:flex;flex:content;align-content:center"; >
        <asp:Button ID="BTN_obtenerpromedio" CssClass="btn btn-primary btn-lg" runat="server" Text="Puntuar" OnClick="BTN_obtenerpromedio_Click"/>
    </div>

    <div class="modal fade" id="MODAL_ELIMINARACTIVIDAD"
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
                    ¿Desea Eliminar Actividad?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="BTN_ACEPTARELIMINACTIVIDAD" OnClick="BTN_ACEPTARELIMINACTIVIDAD_Click" runat="server" class="btn btn-primary" Text="Aceptar"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HF_EliminarActividad" runat="server" />
    <asp:HiddenField ID="HF_EditarActividad" runat="server" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Protocolos.aspx.cs" Inherits="Laboratorio.Protocolos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="float: right">
        <asp:Button runat="server"
            CssClass="btn btn-default"
            Text="Volver a Proyectos" ID="BTN_BACK_PROYECTOS"
            OnClick="BTN_BACK_PROYECTOS_Click" />
    </div>
    <asp:HiddenField ID="HF_Idproyecto" runat="server" />
    <asp:Button runat="server"
        ID="BTN_NUEVO_PROTOCOLO"
        CssClass="btn btn-block btn-success btn-lg"
        OnClick="BTN_NUEVO_PROTOCOLO_Click"
        Text="Nuevo Protocolo" />
    <asp:Panel CssClass="jumbotron" ID="PNL_AGREGAR_PROTOCOLO" runat="server" Visible="false">
        <asp:ImageButton ID="BTN_CANCELAR_NUEVO_PROTOCOLO"
            ImageUrl="fonts\Iconos\icono_x.svg"
            runat="server"
            ImageAlign="right"
            AlternateText="Cancelar"
            OnClick="BTN_CANCELAR_NUEVO_PROTOCOLO_Click" />
        <br />
        <br />
        <div class="row">
            <div class="col-md-6 ">
                <asp:Label ID="LBL_NOMBREPROTOCOLO" runat="server" Text="INGRESE NOMBRE PROTOCOLO"></asp:Label>
                <asp:TextBox ID="TXT_NOMBREPROTOCOLO" CssClass="form-control"
                    runat="server"
                    TextMode="SingleLine"
                    placeholder="Ingrese el nombre del Protocolo"
                    Width="266px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LBL_INGRESEOBSERVACIONESPROTOCOLO" runat="server" Text="INGRESE OBSERVACIONES"></asp:Label>
                <br />
                <asp:TextBox ID="TXT_OBSERVACIONES_PROTOCOLO"
                    placeholder="Observaciones"
                    runat="server"
                    Width="328px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="LBL_SELECCIONERESPONSABLEPROTOCOLO" runat="server" Text="SELECCIONES UN RESPONSABLE DE PROTCOLO"></asp:Label>
                <br />
                <asp:DropDownList ID="DDL_RESPONSABLEPROTOCOLO" runat="server" AutoPostBack="FALSE"></asp:DropDownList>
                <br />
                <br />
                <br />
            </div>
            <div class="col-md-6">
                <asp:Label ID="LBL_TituloCalendar"
                    runat="server"
                    Text="Ingrese Fecha de Finalizacion del Protocolo"></asp:Label>
                <asp:Calendar ID="FECHAFIN_PROTOCOLO"
                    runat="server"
                    Width="350px"></asp:Calendar>
                <br />
            </div>
        </div>
        <div style="text-align: center">
            <asp:Button ID="BTN_AGREGAR_PROTOCOLO"
                runat="server"
                CssClass="btn btn-primary btn-lg"
                Text="Agregar Protocolo"
                OnClick="BTN_AGREGAR_PROTOCOLO_Click"
                HorizontalAlign="center" />
        </div>
    </asp:Panel>
    <br />
    <div style="display:flex;flex-direction:row; justify-content:space-between">
    <asp:Label ID="LBL_IDPROYECTO" runat="server"></asp:Label>
    <asp:Button ID="BTN_MOSTRARTODOSLOSPROTOCOLOS"
            Text="Ver todos los protocolos"
            runat="server"
            Visible="false"
            OnClick="BTN_MOSTRARTODOSLOSPROTOCOLOS_Click" />
        </div>
    <div class="row">
        <div class="col-md-12">
            
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
                     <asp:TemplateField HeaderText="Id Proyecto">
                        <ItemTemplate>
                            <%# Eval("IdProyecto")%>
                        </ItemTemplate>
                    </asp:TemplateField>
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
                    <asp:TemplateField HeaderText="Responsable">
                        <ItemTemplate>
                            <%# Eval("Responsable")%>
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
                    <asp:TemplateField HeaderText="EDITAR">
                        <ItemTemplate>
                            <asp:LinkButton ID="LINK_EDITAR_PROTOCOLOS" runat="server"
                                Text="EDITAR"
                                CssClass="btn btn-warning"
                                CommandName="EDITAR"
                                CommandArgument='<%# Eval("IdProtocolo") %>' Visible='<%# this.protocolofinalizado(int.Parse((Eval("IdProtocolo").ToString()))) %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BORRAR">
                        <ItemTemplate>
                            <asp:LinkButton ID="LINK_ELIMINAR_PROTOCOLOS" runat="server"
                                Text="ELIMINAR"
                                CssClass="btn btn-danger"
                                CommandName="ELIMINAR"
                                CommandArgument='<%# Eval("IdProtocolo") %>' Visible='<%# this.protocolofinalizado(int.Parse((Eval("IdProtocolo").ToString()))) %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ACTIVIDADES">
                        <ItemTemplate>
                            <asp:HyperLink ID="LINK_IR_ACTIVIDADES"
                                runat="server"
                                Text="VER"
                                NavigateUrl='<%# string.Format("~/Actividades.aspx?IdProtocolo={0}", Eval("IdProtocolo")) %>'
                                PostBackUrl="~/Protocolos.aspx"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </div>
     <br /> 

    <asp:HiddenField ID="HF_FINPROYECTO" runat="server" />
    <div class="modal fade" id="MODAL_ELIMINARPROTOCOLO"
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
                    ¿Desea Eliminar el Protocolo?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="BTN_ACEPTARELIMINAPROTOCOLO" OnClick="BTN_ACEPTARELIMINAPROTOCOLO_Click" runat="server" class="btn btn-primary" Text="Aceptar"></asp:Button>
                
                </div>
            </div>
        </div>
    </div>
     <div class="modal fade" id="MODAL_NUMFINPROYECTO"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalCenterTitle"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title"> LABORATORIO LASTONASBEACH</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    INGRESE EL NUMERO DEL PROYECTO A ELIMINAR 
                   <asp:TextBox runat="server" ID="TXT_NUMPROYECTO" placeholder="Ingrese numero de proyecto que desea finalizar" ></asp:TextBox>
                </div>
                <div class="modal-footer">
                      <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    
                </div>
            </div>
        </div>
    </div>

     <div class="modal fade" id="MODAL_ACEPTARFINPROYECTO"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalCenterTitle"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title"> LABORATORIO LASTONASBEACH</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿ESTA SEGURO QUE DESEA FINALIZAR EL PROYECTO?
                </div>
                <div class="modal-footer">
                      <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>

                    
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ModalCamposerroneos"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalCenterTitle"
        aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="ModalCamposerroneostitulo">Validacion</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    POR FAVOR COMPLETE TODOS LOS CAMPOS OBLIGATORIOS
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Aceptar</button>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HF_EDITARPROTOCOLO" runat="server" />
    <asp:HiddenField ID="HF_ELIMINARPROTOCOLO" runat="server" />
</asp:Content>

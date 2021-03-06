﻿Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports BS = Tecorp.Cores.WebApi.Base.FuncionesWebApi
Imports BEnum = Tecorp.Cores.WebApi.Base.Enumerador
Imports BE = Tecorp.Cores.WebApi.Entidad

Namespace Negocio
    Public Class FirmaDigital



#Region "Declaracion de variables"
        Private _ServidorWebApi As String
        Private _PDFV1 As String
        Private _PDFV2 As String
        Private _Path_EP2 As String
        Private _Path_EL2 As String
        Private _Path_ES2 As String
        Private _userEP2 As String
        Private _PasswordEP2 As String
        Private _userEL2 As String
        Private _PasswordEL2 As String
        Private _userES2 As String
        Private _PasswordES2 As String
        Private _RectangleWith As Integer
        Private _RectangleHeight As Integer
        Private _RectangleX As Integer
        Private _RectangleY As Integer
        Private objJSON As JObject

#End Region

#Region "Declaracion de propiedades"
        Private Property ServidorWebApi() As String
            Get
                Return _ServidorWebApi
            End Get
            Set(ByVal value As String)
                _ServidorWebApi = value
            End Set
        End Property

        Private Property PDFV1_URL() As String
            Get
                Return _PDFV1
            End Get
            Set(ByVal value As String)
                _PDFV1 = value
            End Set
        End Property

        Private Property PDFV2_URL() As String
            Get
                Return _PDFV2
            End Get
            Set(ByVal value As String)
                _PDFV2 = value
            End Set
        End Property

        Private Property Path_EP2() As String
            Get
                Return _Path_EP2
            End Get
            Set(ByVal value As String)
                _Path_EP2 = value
            End Set
        End Property

        Private Property Path_EL2() As String
            Get
                Return _Path_EL2
            End Get
            Set(ByVal value As String)
                _Path_EL2 = value
            End Set
        End Property

        Private Property Path_ES2() As String
            Get
                Return _Path_ES2
            End Get
            Set(ByVal value As String)
                _Path_ES2 = value
            End Set
        End Property

        Public Property User_ES2() As String
            Get
                Return _userES2
            End Get
            Set(ByVal value As String)
                _userES2 = value
            End Set
        End Property

        Public Property Password_ES2() As String
            Get
                Return _PasswordES2
            End Get
            Set(ByVal value As String)
                _PasswordES2 = value
            End Set
        End Property

        Public Property User_EL2() As String
            Get
                Return _userEL2
            End Get
            Set(ByVal value As String)
                _userEL2 = value
            End Set
        End Property

        Public Property Password_EL2() As String
            Get
                Return _PasswordEL2
            End Get
            Set(ByVal value As String)
                _PasswordEL2 = value
            End Set
        End Property

        Public Property User_EP2() As String
            Get
                Return _userEP2
            End Get
            Set(ByVal value As String)
                _userEP2 = value
            End Set
        End Property

        Public Property Password_EP2() As String
            Get
                Return _PasswordEP2
            End Get
            Set(ByVal value As String)
                _PasswordEP2 = value
            End Set
        End Property

        Public Property Rectangle_With() As Integer
            Get
                Return _RectangleWith
            End Get
            Set(ByVal value As Integer)
                _RectangleWith = value
            End Set
        End Property
        Public Property Rectangle_Height() As Integer
            Get
                Return _RectangleHeight
            End Get
            Set(ByVal value As Integer)
                _RectangleHeight = value
            End Set
        End Property
        Public Property Rectangle_X() As Integer
            Get
                Return _RectangleX
            End Get
            Set(ByVal value As Integer)
                _RectangleX = value
            End Set
        End Property
        Public Property Rectangle_Y() As Integer
            Get
                Return _RectangleY
            End Get
            Set(ByVal value As Integer)
                _RectangleY = value
            End Set
        End Property

#End Region

#Region "Metodos para leer el archivo de configuración Json"
        Private Function getValor(ByVal key As String) As String
            Return objJSON("ConfiguracionFirmaDigital").Item(key).ToString()
        End Function
#End Region

#Region "Metodos para firma digital "


        ''' <summary>
        ''' Firma un archivo PDF lo guarda en la ruta que se especifica y devuelve el archivo firmado
        ''' </summary>
        ''' <param name="BEFirmaDigital"></param>
        ''' <param name="CoreSistema"></param>
        ''' <returns></returns>
        Public Async Function PdfV1_AgregarFirmaDigital(ByVal BEFirmaDigital As BE.RequestFirmaDigital, ByVal CoreSistema As BEnum.TipoCore) As Task(Of BE.ResponseFirmaDigital)
            Dim BEResponseFirmaDigital As New BE.ResponseFirmaDigital
            Dim strRequestJson As String = String.Empty
            Dim strResponseJson As String = String.Empty
            Try
                AgregarPath(BEFirmaDigital, CoreSistema)
                strRequestJson = JsonConvert.SerializeObject(BEFirmaDigital, Formatting.Indented)
                strResponseJson = Await BS.PostRequest(ServidorWebApi, PDFV1_URL, strRequestJson)
                BEResponseFirmaDigital = JsonConvert.DeserializeObject(Of BE.ResponseFirmaDigital)(strResponseJson)

            Catch ex As Exception
                BEResponseFirmaDigital.signedDocs = 0
                BEResponseFirmaDigital.unsignedDocs = 0
                BEResponseFirmaDigital.totalDocs = 0
                BEResponseFirmaDigital.summary = "Error en la transacción"
                BEResponseFirmaDigital.messages = New List(Of String)
                BEResponseFirmaDigital.messages.Add(ex.Message)
                BEResponseFirmaDigital.code = 0
                BEResponseFirmaDigital.status = 0
                BEResponseFirmaDigital.statusPhrase = "FALSE"
                Return BEResponseFirmaDigital
            End Try

            Return BEResponseFirmaDigital
        End Function

        ''' <summary>
        ''' Firma un archivo PDF lo guarda y devuelve el archivo firmado
        ''' </summary>
        ''' <param name="BEFirmaDigital"></param>
        ''' <returns></returns>
        Public Async Function PdfV2_AgregarFirmaDigital(ByVal BEFirmaDigital As BE.RequestFirmaDigital) As Task(Of BE.ResponseFirmaDigital)
            Dim BEResponseFirmaDigital As New BE.ResponseFirmaDigital
            Dim strRequestJson As String = String.Empty
            Dim strResponseJson As String = String.Empty
            Try
                strRequestJson = JsonConvert.SerializeObject(BEFirmaDigital, Formatting.Indented)
                strResponseJson = Await BS.PostRequest(ServidorWebApi, PDFV2_URL, strRequestJson)
                BEResponseFirmaDigital = JsonConvert.DeserializeObject(Of BE.ResponseFirmaDigital)(strResponseJson)
            Catch ex As Exception
                BEResponseFirmaDigital.signedDocs = 0
                BEResponseFirmaDigital.unsignedDocs = 0
                BEResponseFirmaDigital.totalDocs = 0
                BEResponseFirmaDigital.summary = "Error en la transacción"
                BEResponseFirmaDigital.messages = New List(Of String)
                BEResponseFirmaDigital.messages.Add(ex.Message)
                BEResponseFirmaDigital.code = 0
                BEResponseFirmaDigital.status = 0
                BEResponseFirmaDigital.statusPhrase = "FALSE"
                Return BEResponseFirmaDigital
            End Try

            Return BEResponseFirmaDigital
        End Function

        Public Function ConvertFileToBase64(ByVal fileName As String) As String
            Dim strResultado As String = String.Empty
            Try
                strResultado = Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName))
            Catch ex As Exception
                Return strResultado
            End Try
            Return strResultado
        End Function

#End Region

#Region "Metodos Auxiliarres"
        Private Function ValidarObjetoFirma(ByVal objFirmaDigital As BE.RequestFirmaDigital, ByRef strMensaje As String) As Boolean
            Dim bolResultado As Boolean = True
            Try
                If objFirmaDigital IsNot Nothing Then

                Else
                    strMensaje = "El objeto no puede estar vacio, por favor cargue los datos necesarios"
                End If
            Catch ex As Exception
                Return False
            End Try
            Return bolResultado
        End Function

        Private Sub AgregarPath(ByRef objFirmaDigital As BE.RequestFirmaDigital, ByVal CoreSistema As BEnum.TipoCore)
            Dim strRutaCompleta As String = String.Empty
            Dim strPath As String = String.Empty
            Try
                Select Case CoreSistema
                    Case BEnum.TipoCore.Elife
                        strPath = Path_EL2
                    Case BEnum.TipoCore.ESalud
                        strPath = Path_ES2
                    Case BEnum.TipoCore.Eproperty2
                        strPath = Path_EP2
                End Select
                If objFirmaDigital IsNot Nothing Then
                    For Each objDoc In objFirmaDigital.documents
                        strRutaCompleta = strPath + objDoc.filename
                        objDoc.filename = strRutaCompleta
                    Next
                End If
            Catch ex As Exception

            End Try
        End Sub


#End Region

#Region "Constructor"
        Sub New()
            objJSON = JObject.Parse(Encoding.UTF8.GetString(My.Resources.ConfiguracionWebAPI))
            ServidorWebApi = getValor("Server_URL")
            PDFV1_URL = getValor("PdfV1_URL")
            PDFV2_URL = getValor("PdfV2_URL")

            User_EL2 = getValor("User_EL2")
            Password_EL2 = getValor("Password_EL2")
            Path_EL2 = getValor("Path_EL2")

            User_ES2 = getValor("User_ES2")
            Password_ES2 = getValor("Password_ES2")
            Path_ES2 = getValor("Path_ES2")

            User_EP2 = getValor("User_EP2")
            Password_EP2 = getValor("Password_EP2")
            Path_EP2 = getValor("Path_EP2")

            Rectangle_With = getValor("Rectangle_With")
            Rectangle_Height = getValor("Rectangle_Height")
            Rectangle_X = getValor("Rectangle_X")
            Rectangle_Y = getValor("Rectangle_Y")

        End Sub
#End Region


    End Class



End Namespace


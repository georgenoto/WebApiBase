Option Explicit On
Option Compare Text
Option Strict On
Option Infer On

Namespace Entidad
    Public Class webDocumento
        Public base64 As String = String.Empty
        Public filename As String = String.Empty
        Public signatureMethod As String = String.Empty
        Public pdfPassword As String = String.Empty
        Public signatureDetails As webSignatureDetails = Nothing
        Public graphicSignature As webGraphicSignature = Nothing
    End Class
End Namespace


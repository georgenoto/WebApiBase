Option Explicit On
Option Compare Text
Option Strict On
Option Infer On

Namespace Entidad
    Public Class webFirmaDigital
        Public user As webUser = Nothing
        Public keystorePin As String = String.Empty
        Public certificateLabel As String = String.Empty
        Public documents As List(Of webDocumento)
    End Class

End Namespace

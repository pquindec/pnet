Imports System.Data.SqlClient
Imports System.Data.Sql
Module Conexion

    Public conexion As SqlConnection
    Public enunciado As SqlCommand
    Public respuesta As SqlDataReader
    Sub abrir()
        Try
            conexion = New SqlConnection("Server=192.168.27.30;DATABASE=farmacia; User id= user; Password=pquinde")
            conexion.Open()
            MsgBox("Conectado", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("No se pudo conectar", MsgBoxStyle.Critical)
        End Try
    End Sub
    Function usuarioRegistrado(ByVal nombreusuario As String) As Boolean
        Dim resul As Boolean = False
        Try
            enunciado = New SqlCommand("Select * from usuarios Where usuario = '" & nombreusuario & "'", conexion)
            respuesta = enunciado.ExecuteReader
            If respuesta.Read Then
                resul = respuesta.Item("contrasena")
            End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resul
    End Function
    Function contrasena(ByVal nombreUsuario As String) As String
        Dim resul As String = ""
        Try

        enunciado = New SqlCommand("Select contrasena from usuarios Where usuario = '" & nombreUsuario & "'", conexion)
        respuesta = enunciado.ExecuteReader
        If respuesta.Read Then
            resul = respuesta.Item("contrasena")
        End If
            respuesta.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return resul
    End Function
End Module

Public Class Form4

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If usuarioRegistrado(txtusuario.Text) = True Then
                Dim contra As String = contrasena(txtusuario.Text)
                If contra.Equals(txtpass.Text) = True Then
                    Form1.ShowDialog()
                    txtusuario.Text = ""
                    txtpass.Text = ""
                Else
                    MsgBox("Contraseña incorrecta", MsgBoxStyle.Critical)

                    txtpass.Text = ""
                End If
            Else
                MsgBox("El usuario: " + txtusuario.Text + " no se encuentra registrado", MsgBoxStyle.Critical)
                txtusuario.Text = ""
                txtpass.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        abrir()
    End Sub
End Class